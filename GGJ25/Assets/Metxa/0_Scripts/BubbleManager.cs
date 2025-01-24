using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleManager : MonoBehaviour
{
    public GameObject Bubble;
    public float SpawnTime = 5f, SpawnTimer;

    void Start()
    {
        SpawnTimer = SpawnTime;
    }

    void Update()
    {
        SpawnTimer -= Time.deltaTime;
        if(SpawnTimer < 0 )
        {
            int[] possibleValues = { -3, 0, 3 };
            Vector3 position = new Vector3(possibleValues[Random.Range(0, possibleValues.Length)], 5, possibleValues[Random.Range(0, possibleValues.Length)]);
            Instantiate(Bubble, position, Quaternion.identity);
            SpawnTimer = SpawnTime;
        }
    }
}
