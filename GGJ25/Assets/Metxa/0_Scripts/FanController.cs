using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanController : MonoBehaviour
{
    public bool SetDirectionTo;
    void Start()
    {
        
    }

    void Update()
    {
        if (SetDirectionTo)
        {
            if (Input.GetButtonDown("Fire3"))
            {
                GetComponent<BoxCollider>().enabled = true;
            }
            else
            {
                GetComponent<BoxCollider>().enabled = false;
            }
        }
        else
        {
            if (Input.GetButtonDown("Fire2"))
            {
                GetComponent<BoxCollider>().enabled = true;
            }
            else
            {
                GetComponent<BoxCollider>().enabled = false;
            }
        }

        if (Input.GetButtonDown("Up"))
        {

        }else if (Input.GetButtonDown("Down"))
        {

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
