using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlantsControler : MonoBehaviour
{
    public List<PlantControler> plants;
    public int Gardenlifes;
    private int actuallife;
    public int Timer;
    private int time;
    private bool pickupcrops;
    private int pickcrop;

    private void Start()
    {
        actuallife = Gardenlifes;
        time = Timer;
        pickupcrops = false;
        pickcrop = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (pickupcrops)
        {
            if (time<0)
            {
                plants[pickcrop].Estado = 0;
                pickcrop++;
                if (pickcrop >= plants.Count)
                {
                    pickcrop = 0;
                    pickupcrops = false;
                }
                time = Timer;
            }
            else
            {
                time--;
            }
           
        }

        int tmpFinish=0;
        for(int i = 0; i < plants.Count; i++)
        {
            tmpFinish += plants[i].Estado;
        }

        if(tmpFinish/4 == plants.Count)
        {
            pickupcrops = true;
        }else if (tmpFinish <= 0)
        {
            if (time<0)
            {
                actuallife--;
                if (actuallife < 0)
                {
                    //Game Over;
                }
                time = Timer;
            }

            time--;
        }
        else
        {
            actuallife = Gardenlifes;
            time = Timer;
        }
    }
}
