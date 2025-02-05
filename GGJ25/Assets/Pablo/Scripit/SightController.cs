using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SightController : MonoBehaviour
{
    private Slider hitbarr;
    private bool right;
    public float speed;
    public ShotControler gun;
    private Transform hitimage;
    public float minRange;
    public bool stop;
    public float maxRange;
    public float ActualRangeMin;
    public float ActualRangeMax;
    public float IntervalSpeedDescres;
    public Vector3 StartingScale;
    bool animation;
    bool index;

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
        animation = false;
        index=true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale != 0)
        {
            if (Input.GetButtonDown("Fire1") == true)
            {
                if (hitbarr.value > ActualRangeMin && hitbarr.value < ActualRangeMax)
                {
                    gun.Shot = true;
                    animation = true;
                    if (ActualRangeMin < 0.3f && ActualRangeMax > 0.7f)
                    {
                        ActualRangeMax -= IntervalSpeedDescres;
                        ActualRangeMin += IntervalSpeedDescres;
                        hitimage.localScale = new Vector3(hitimage.localScale.x - ((IntervalSpeedDescres * StartingScale.x) / 0.2f), StartingScale.y, StartingScale.z);

                    }
                }
                else
                {
                    ActualRangeMax = maxRange;
                    ActualRangeMin = minRange;
                    hitimage.transform.localScale = StartingScale;
                }

            }
        }
       

        if (animation)
        {
                
                if (index)
                {

                    transform.GetChild(0).GetChild(6).localScale = new Vector3(transform.GetChild(0).GetChild(6).localScale.x - 0.01f, transform.GetChild(0).GetChild(6).localScale.y - 0.01f, transform.GetChild(0).GetChild(6).localScale.z - 0.01f);
                    if (transform.GetChild(0).GetChild(6).localScale.x < 0.002f)
                    {
                        index = false;
                    }
                }
                else
                {
                    Debug.Log(transform.GetChild(0).GetChild(6).localScale.x);

                        animation = false;
                        index = true;
                        transform.GetChild(0).GetChild(6).localScale = new Vector3(0.086f, 0.15f, 0.064f);
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
