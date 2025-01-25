using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantControler : MonoBehaviour
{
    public int Estado;
    public List<Sprite> Sprites;
    private BoxCollider ColliderPlant;
    private BillboardController Body;
    private Rigidbody rig_;
    public Vector3 SizeOfobject;

    // Start is called before the first frame update
    void Start()
    {
        Estado = 0;
        ColliderPlant = GetComponent<BoxCollider>();
        Body = GetComponentInChildren<BillboardController>();
        rig_ = GetComponent<Rigidbody>();
        Body.ChangeImagen(Sprites[Estado]);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bubble"))
        {

            BubbleMovement avg = other.GetComponent<BubbleMovement>();

            if(avg.Type- 1 == Estado)
            {
                //Debug.Log("Growing");
                Estado++;
                Body.ChangeImagen(Sprites[Estado]);
            }
            else if(avg.Type < 0)
            {
                //Debug.Log("Dying");
                Estado += avg.Type;
                if (Estado < 0)
                {
                    Estado = 0;
                }
                Body.ChangeImagen(Sprites[Estado]);
            }

            Destroy(other.transform.gameObject);
        }  
    }
}
