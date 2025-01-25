using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    public List<Sprite> clouds;
    private SpriteRenderer sprites;
    private bool right;
    public float speed;

    void Start()
    {
        sprites = GetComponent<SpriteRenderer>();
        if (Random.Range(0, 1) == 1)
        {
            right = true;
            transform.position = new Vector3(-40, Random.Range(5, 10), 18);
        }
        else
        {
            right = false;
            transform.position = new Vector3(40,Random.Range(5,10),18);
        }
    }

    void Update()
    {
        if (right)
        {
            transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);
        }

        if(transform.position.x < -42 || transform.position.x > 42)
        {
           sprites.sprite = clouds[Random.Range(0, 1)];
            if (Random.Range(0, 1) == 1)
            {
                right = true;
                transform.position = new Vector3(-40, Random.Range(5, 10), 18);
            }
            else
            {
                right = false;
                transform.position = new Vector3(40, Random.Range(5, 10), 18);
            }
        }
    }
}
