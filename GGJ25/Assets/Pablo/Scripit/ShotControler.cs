using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotControler : MonoBehaviour
{
    public Camera mainCamera;
    public bool Shot;
    //public int RangeOfShot = 5;
    // Start is called before the first frame update
    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }

        Shot = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Shot)
        {
            Vector3 PositionOfRay = new Vector3(Input.mousePosition.x /*+  Random.Range(-RangeOfShot, RangeOfShot)*/, Input.mousePosition.y /*+  Random.Range(-RangeOfShot, RangeOfShot)*/, Input.mousePosition.z);
            Ray ray = mainCamera.ScreenPointToRay(PositionOfRay);
            RaycastHit hit;

            Debug.DrawRay(ray.origin, ray.direction * 100,new Color(255,0,0) , 2f);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.CompareTag("Bubble"))
                {
                    Destroy(hit.collider.gameObject);
                }
            }
            Shot = false;
        }
    }
}
