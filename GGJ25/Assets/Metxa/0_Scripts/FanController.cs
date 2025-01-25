using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanController : MonoBehaviour
{
    public bool SetDirectionTo;

    void Update()
    {
        if (SetDirectionTo)
        {
            if (Input.GetButton("Fire3"))
            {
                GetComponent<BoxCollider>().enabled = true;
                Debug.Log("Fire Right");
            }
            else
            {
                GetComponent<BoxCollider>().enabled = false;
            }
        }
        else
        {
            if (Input.GetButton("Fire2"))
            {
                GetComponent<BoxCollider>().enabled = true;
                Debug.Log("Fire Left");
            }
            else
            {
                GetComponent<BoxCollider>().enabled = false;
            }
        }

        if (Input.GetButtonDown("Up"))
        {
            if (transform.position.y < 5)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
            }
            Debug.Log(transform.position.y);
        }else if (Input.GetButtonDown("Down"))
        {
            if (transform.position.y > 3)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
            }
            Debug.Log(transform.position.y);
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
