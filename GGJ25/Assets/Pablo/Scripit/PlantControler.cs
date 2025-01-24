using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantControler : MonoBehaviour
{
    public int Estado;
    public List<Material> Sprites;
    private BoxCollider ColliderPlant;
    private BillboardController Body;

    // Start is called before the first frame update
    void Start()
    {
        Estado = 0;
        ColliderPlant = GetComponent<BoxCollider>();
        Body = GetComponent<BillboardController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Body.GetComponent<MeshRenderer>().material = Sprites[Estado];
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
