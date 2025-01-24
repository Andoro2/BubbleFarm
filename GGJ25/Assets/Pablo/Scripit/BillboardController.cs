using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardController : MonoBehaviour
{
    void LateUpdate()
    {
        transform.LookAt(Camera.main.transform.position);
        transform.rotation = Quaternion.LookRotation(Camera.main.transform.position - transform.position);
        transform.Rotate(180, 0, 180);
    }
}
