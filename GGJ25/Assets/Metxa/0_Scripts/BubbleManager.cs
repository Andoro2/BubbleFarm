using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleManager : MonoBehaviour
{
    public GameObject Bubble;
    public float SpawnTime = 5f, SpawnTimer;
    private List<GameObject> Plants = new List<GameObject>();
    private int PlantLevels = 0; // 15 plantas * 4 niveles = 60

    void Start()
    {
        SpawnTimer = SpawnTime;

        GameObject[] plantsArray = GameObject.FindGameObjectsWithTag("Plant");

        Plants = new List<GameObject>(plantsArray);
    }

    void Update()
    {
        SpawnTimer -= Time.deltaTime;
        if(SpawnTimer < 0 )
        {
            int[] possibleZValues = { 6, 3, 0 };
            Vector3 position = new Vector3(Random.Range(-2, 2), 9, possibleZValues[Random.Range(0, possibleZValues.Length)]);
            Instantiate(Bubble, position, Quaternion.identity);
            SpawnTimer = SpawnTime;
        }
    }

    void CountLevels()
    {
        foreach (GameObject Plantas in Plants)
        {
            PlantLevels += Plantas.GetComponent<PlantControler>().Estado;
        }
        if(PlantLevels != 60)
        {
            PlantLevels = 0;
        }
    }
}
