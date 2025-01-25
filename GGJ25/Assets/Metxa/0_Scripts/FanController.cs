using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanController : MonoBehaviour
{
    public bool SetDirectionTo,
        FanOn = false;
    void Start()
    {
        
    }

    void Update()
    {
        if (FanOn)
        {
            GetComponent<BoxCollider>().enabled = true;
        }
        else
        {
            GetComponent<BoxCollider>().enabled = false;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (GetComponent<BoxCollider>().enabled)
        {
            if (other.gameObject.CompareTag("Bubble"))
            {
                Debug.Log("Bubel");
                if (other.gameObject.GetComponent<BubbleMovement>().Direction != SetDirectionTo) other.gameObject.GetComponent<BubbleMovement>().Direction = SetDirectionTo;
            }
        }
    }
}
