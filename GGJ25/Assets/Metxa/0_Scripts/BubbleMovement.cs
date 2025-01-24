using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleMovement : MonoBehaviour
{
    public int Type = 0, BadnessChance = 5,
        DownSpeed = 2,  SideSpeed = 8;
    public bool Direction = true; // true = derecha / false = izquierda
    void Start()
    {
        Type = Random.Range(1, 4);
        if(Random.Range(1, 10) < BadnessChance)
        {
            Type *= -1;
            if (Type == -3)
            {
                if (Random.Range(1, 4) < 1) Type++;
                else Type--;
            }
        }

        if (Random.Range(0,2) == 0) Direction = true;
        else Direction = false;
    }

    void Update()
    {
        transform.Translate(Vector3.down * DownSpeed * Time.deltaTime);
        if(Direction)
        {
            transform.Translate(Vector3.right * SideSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * SideSpeed * Time.deltaTime);
        }

        if(transform.position.y < 0) Destroy(this.transform.gameObject);
    }
}
