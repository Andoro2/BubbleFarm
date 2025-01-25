using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoScript : MonoBehaviour
{
    public SightController hitter;
    void Start()
    {
        Time.timeScale = 0f;
        //hitter = GetComponent<SightController>();
        hitter.stop = true;
    }

    void Update()
    {
        if (Input.GetButtonDown(("Down")))
        {
            Time.timeScale = 1f;
            hitter.stop = false;
            Destroy(this.gameObject);
        }
    }
}
