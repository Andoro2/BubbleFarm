using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SightController : MonoBehaviour
{
    private Slider hitbarr;
    private bool right;
    public float speed;
    public float coneAngle = 45f; // Ángulo del cono (en grados)
    public float coneDistance = 10f; // Distancia máxima del cono
    public int rayCount = 10; // Número de rayos dentro del cono
    public ShotControler gun;

    // Start is called before the first frame update
    void Start()
    {
        hitbarr = transform.GetChild(0).GetComponent<Slider>();
        hitbarr.value = 0.5f;
        right = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")==true)
        {
            gun.timer = gun.TimeOfShot;
        }
        

        if (right)
        {
            hitbarr.value += speed;
            if (hitbarr.value >= 1.0f)
            {
                right = false;
            }
        }
        else
        {
            hitbarr.value -= speed;
            if (hitbarr.value <= 0.0f)
            {
                right = true;
            }
        }
    }
}
