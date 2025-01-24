using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BubbleMovement : MonoBehaviour
{
    public int Type = 0, BadnessChance = 5,
        DownSpeed = 2,  SideSpeed = 8;
    public bool Direction = true; // true = derecha / false = izquierda
    public List<Sprite> BubbleSprites = new List<Sprite>();
    public List<Sprite> ItemSprites = new List<Sprite>();
    public float GroundY = -5;
    BillboardController BC;
    private GameObject Shadow;
    private float ShadowYValue;

    void Start()
    {
        Type = Random.Range(1, 4);

        BC = transform.GetChild(0).GetComponent<BillboardController>();

        if (Random.Range(1, 10) < BadnessChance)
        {
            BC.ChangeImagen(BubbleSprites[Random.Range(3, 6)]);
            Type *= -1;
            if (Type == -3)
            {
                if (Random.Range(1, 4) < 1) Type++;
                else Type--;
            }
        }
        else
        {
            BC.ChangeImagen(BubbleSprites[Random.Range(0, 3)]);
        }

        if (Random.Range(0,2) == 0) Direction = true;
        else Direction = false;

        Shadow = transform.GetChild(1).transform.gameObject;
        Shadow.transform.position = new Vector3(Shadow.transform.position.x, GroundY, Shadow.transform.position.z);
        ShadowYValue = Shadow.transform.position.y;
    }

    void Update()
    {
        transform.Translate(Vector3.down * DownSpeed * Time.deltaTime);
        Shadow.transform.Translate(Vector3.up * DownSpeed * Time.deltaTime);
        if (Direction)
        {
            transform.Translate(Vector3.right * SideSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * SideSpeed * Time.deltaTime);
        }

        if(transform.position.y < 0) Destroy(this.transform.gameObject);
        Shadow.transform.position = new Vector3(Shadow.transform.position.x, ShadowYValue, Shadow.transform.position.z);
    }
}
