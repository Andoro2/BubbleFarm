using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BubbleMovement : MonoBehaviour
{
    public int Type = 0;
    public float BadnessChance = 2.5f,
        DownSpeed = 2f,  SideSpeed = 8f;
    public bool Direction = true; // true = derecha / false = izquierda
    public List<Sprite> BubbleSprites = new List<Sprite>();
    public List<Sprite> ItemSprites = new List<Sprite>();
    public float GroundY = -5;
    BillboardController BC;
    BillboardController BCitem;
    private GameObject Shadow, Particula;
    public float Dyingheight;

    void Start()
    {
        Particula = transform.GetChild(3).transform.gameObject;
        Type = Random.Range(1, 4);

        BC = transform.GetChild(0).GetComponent<BillboardController>();
        BCitem = transform.GetChild(1).GetComponent<BillboardController>();

        if (Random.Range(1, 10) < BadnessChance)
        {
            BC.ChangeImagen(BubbleSprites[Random.Range(3, 6)]);//malo maloso
            Type *= -1;
            if (Type == -3)
            {
                if (Random.Range(1, 4) < 1) Type++;
                else Type--;
            }

            int tmpType = Type * -1;

            if (tmpType == 4)
            {
                BCitem.ChangeImagen(ItemSprites[tmpType + 2]);
            }
            else
            {
                BCitem.ChangeImagen(ItemSprites[tmpType + 3]);
            }
        }
        else// bueno buenoso
        {
            BC.ChangeImagen(BubbleSprites[Random.Range(0, 3)]);
            BCitem.ChangeImagen(ItemSprites[Type-1]);
        }

        if (Random.Range(0,2) == 0) Direction = true;
        else Direction = false;

        Shadow = transform.GetChild(2).transform.gameObject;
        Shadow.transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }

    void Update()
    {
        transform.Translate(Vector3.down * DownSpeed * Time.deltaTime);
        if(null == Shadow)
        {
            Shadow = transform.GetChild(2).transform.gameObject;
        }
        else
        {
            Shadow.transform.Translate(Vector3.up * DownSpeed * Time.deltaTime);
        }

    }
    public void PopSystem()
    {
        Debug.Log("Tuputamadre");
        Particula.SetActive(true);
        Particula.transform.SetParent(null);
    }
}
