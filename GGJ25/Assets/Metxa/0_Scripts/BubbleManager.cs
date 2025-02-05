using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleManager : MonoBehaviour
{
    public GameObject Bubble;
    public float SpawnTime = 5f;
    private float Timer;
    private List<GameObject> Plants = new List<GameObject>();
    private int PlantLevels = 0; // 15 plantas * 4 niveles = 60

    void Start()
    {
        Timer = SpawnTime;

        GameObject[] plantsArray = GameObject.FindGameObjectsWithTag("Plant");

        Plants = new List<GameObject>(plantsArray);
    }

    void Update()
    {
        Timer -= Time.deltaTime;
        if(Timer < 0 )
        {
            float[] possibleZValues = { -2.82f, 0.18f, 3.18f };
            int tmp = Random.Range(0, possibleZValues.Length);
            Vector3 position = new Vector3(Random.Range(-2, 2), 9, possibleZValues[tmp]);
            GameObject avg = Instantiate(Bubble, position, Quaternion.identity);

            Timer = SpawnTime;
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
