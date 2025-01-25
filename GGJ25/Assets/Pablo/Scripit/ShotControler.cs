using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotControler : MonoBehaviour
{
    public float coneAngle; // �ngulo del cono en grados
    public float coneDistance; // Distancia m�xima del cono
    public int raysCount; // N�mero total de rayos a lanzar
    public int timer;
    public int TimeOfShot;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer>0)
        {
            Vector3 coneOrigin = new Vector3(transform.position.x,transform.position.y+3,transform.position.z); // Origen del cono
            Vector3 coneDirection = transform.forward; // Direcci�n central del cono

            for (int i = 0; i < raysCount; i++)
            {
                // Generar una direcci�n dentro del cono
                Vector3 rayDirection = GetDirectionInCone(coneDirection, coneAngle);

                // Realizar el Raycast
                Ray coneRay = new Ray(coneOrigin, rayDirection);
                RaycastHit hit;

                if (Physics.Raycast(coneRay, out hit, coneDistance))
                {
                    if (hit.transform.CompareTag("Bubble"))
                    {
                        Destroy(hit.transform.gameObject);
                        Debug.DrawRay(coneOrigin, rayDirection * hit.distance, Color.green);
                    }
                }
                else
                {
                    Debug.DrawRay(coneOrigin, rayDirection * coneDistance, Color.red);
                }
            }
            timer--;
        }
    }

    Vector3 GetDirectionInCone(Vector3 forwardDirection, float angle)
    {
        // Convertir el �ngulo a radianes
        float coneAngleRadians = Mathf.Deg2Rad * angle;

        // Generar un �ngulo aleatorio en el rango [0, 2?] para la rotaci�n alrededor del eje
        float azimuth = Random.Range(0f, 2f * Mathf.PI);

        // Generar un �ngulo aleatorio de elevaci�n dentro del rango del cono
        float elevation = Random.Range(0f, coneAngleRadians);

        // Convertir coordenadas esf�ricas a cartesianas para generar el vector
        float x = Mathf.Sin(elevation) * Mathf.Cos(azimuth);
        float y = Mathf.Sin(elevation) * Mathf.Sin(azimuth);
        float z = Mathf.Cos(elevation);

        // Generar la direcci�n en el espacio local del cono
        Vector3 localDirection = new Vector3(x, y, z);

        // Rotar la direcci�n local para alinearla con la direcci�n principal del cono
        return Quaternion.LookRotation(forwardDirection) * localDirection;
    }
}
