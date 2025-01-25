using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SightController : MonoBehaviour
{
    private Slider hitbarr;
    private bool right;
    public float speed;
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
