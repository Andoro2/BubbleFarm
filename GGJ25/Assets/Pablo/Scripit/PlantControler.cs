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

    // Start is called before the first frame update
    void Start()
    {
        Estado = 0;
        ColliderPlant = GetComponent<BoxCollider>();
        Body = GetComponentInChildren<BillboardController>();
        rig_ = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Estado < 0)
        {
            Estado = 0;
        }

        Body.ChangeImagen(Sprites[Estado]);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bubble"))
        {
            Debug.Log("Hello");

            BubbleMovement avg = other.GetComponent<BubbleMovement>();

            if(avg.Type- 1 == Estado)
            {
                Estado++;
            }else if(avg.Type < 0)
            {
                Estado += avg.Type;
            }

            Destroy(other);
        }  
    }
}
