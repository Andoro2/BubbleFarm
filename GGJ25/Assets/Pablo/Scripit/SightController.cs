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
    private Transform hitimage;
    public float minRange;
    public bool stop;
    public float maxRange;
    public float ActualRangeMin;
    public float ActualRangeMax;
    public float IntervalSpeedDescres;
    public Vector3 StartingScale;

    // Start is called before the first frame update
    void Start()
    {
        hitbarr = transform.GetChild(0).GetChild(3).GetComponent<Slider>();
        hitimage = transform.GetChild(0).GetChild(2).GetComponent<Transform>();
        hitbarr.value = 0.5f;
        right = true;
        stop = false;
        ActualRangeMax = maxRange;
        ActualRangeMin = minRange;
        hitimage.transform.localScale = StartingScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")==true)
        {
            if (hitbarr.value>ActualRangeMin && hitbarr.value<ActualRangeMax)
            {
                gun.timer = gun.TimeOfShot;
                if (ActualRangeMin<0.3f && ActualRangeMax>0.7f)
                {
                    ActualRangeMax -= IntervalSpeedDescres;
                    ActualRangeMin += IntervalSpeedDescres;
                    hitimage.localScale = new Vector3(hitimage.localScale.x - ((IntervalSpeedDescres*StartingScale.x)/0.2f), StartingScale.y, StartingScale.z);

                }
            }
            else {
                ActualRangeMax = maxRange;
                ActualRangeMin = minRange;
                hitimage.transform.localScale = StartingScale;
            }
        }
        

        if(!stop){
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
}
