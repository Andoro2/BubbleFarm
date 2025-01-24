using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BillboardController : MonoBehaviour
{
    void LateUpdate()
    {
        transform.LookAt(Camera.main.transform.position);
        transform.rotation = Quaternion.LookRotation(Camera.main.transform.position - transform.position);
        transform.Rotate(180, 0, 180);
    }

    public void ChangeImagen(Sprite image)
    {
        transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = image;
    }
}
