using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class PlantControler : MonoBehaviour
{
    public int Estado;
    public List<Sprite> Sprites;
    private BoxCollider ColliderPlant;
    private BillboardController Body;
    private Rigidbody rig_;
    public Vector3 SizeOfobject;
    private AudioManager audio;
    public AudioClip audioGrow;
    public AudioClip audioDamage;
    public AudioClip audioDeath;
    private GameObject Particula;

    // Start is called before the first frame update
    void Start()
    {
        Estado = 0;
        ColliderPlant = GetComponent<BoxCollider>();
        Body = GetComponentInChildren<BillboardController>();
        rig_ = GetComponent<Rigidbody>();
        Body.ChangeImagen(Sprites[Estado]);
        audio = GameObject.Find("AudioSource").GetComponent<AudioManager>();

        Particula = transform.GetChild(1).transform.gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bubble"))
        {

            BubbleMovement avg = other.GetComponent<BubbleMovement>();
            avg.PopSystem();

            if(avg.Type- 1 == Estado)
            {
                if(Estado==0){
                    Body.transform.position = new Vector3(Body.transform.position.x, Body.transform.position.y, Body.transform.position.z + 2.5f);
                }
                
                Estado++;
                Body.ChangeImagen(Sprites[Estado]);
                audio.Effect(audioGrow);


                Particula.SetActive(true);
                Particula.transform.SetParent(null);
            }
            else if(avg.Type < 0)
            {
                if (Estado != 0) {
                    Estado += avg.Type;
                    if (Estado <= 0)
                    {
                        Body.transform.position = new Vector3(Body.transform.position.x, Body.transform.position.y, Body.transform.position.z - 2.5f);
                        Estado = 0;
                        audio.Effect(audioDeath);

                    }
                    else
                    {
                        audio.Effect(audioDamage);
                    }
                    Body.ChangeImagen(Sprites[Estado]);
                }
            }

            Destroy(other.transform.gameObject);
        }  
    }
}
