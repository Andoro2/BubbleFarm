using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FanController : MonoBehaviour
{
    public bool SetDirectionTo;
    public GameObject FanLeft;
    public GameObject FanRight;
    public List<Sprite> FanIcon;
    public Animator FanAnim;
    public Animator WintAnim;
    public AudioManager audio;
    public AudioClip Move;
    //public AudioClip Wint;

    private void Start()
    {
        FanRight.GetComponent<Image>().sprite = FanIcon[0];
        FanLeft.GetComponent<Image>().sprite = FanIcon[0];
        audio = GameObject.Find("AudioSource").GetComponent<AudioManager>();
        FanAnim = transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Animator>();
        WintAnim = transform.GetChild(1).GetComponent<Animator>();
    }

    void Update()
    {
        if (SetDirectionTo)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                GetComponent<BoxCollider>().enabled = !GetComponent<BoxCollider>().enabled;
                if (GetComponent<BoxCollider>().enabled)
                {
                    FanLeft.GetComponent<Image>().sprite = FanIcon[1];
                }
                else
                {
                    FanLeft.GetComponent<Image>().sprite = FanIcon[0];
                }
                
                Debug.Log("Fire Right");
            }

            if (Input.GetButtonDown("Up"))
            {
                if (transform.position.y < 7)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
                    audio.Effect(Move);
                }
                Debug.Log(transform.position.y);
            }
            else if (Input.GetButtonDown("Down"))
            {
                if (transform.position.y > 3)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
                    audio.Effect(Move);
                }
                Debug.Log(transform.position.y);
            }

        }
        else
        {
            if (Input.GetButtonDown("Fire3"))
            {
                GetComponent<BoxCollider>().enabled = !GetComponent<BoxCollider>().enabled;
                if (GetComponent<BoxCollider>().enabled)
                {
                    FanRight.GetComponent<Image>().sprite = FanIcon[1];
                }
                else
                {
                    FanRight.GetComponent<Image>().sprite = FanIcon[0];
                }
                Debug.Log("Fire Left");
            }

            if (Input.GetButtonDown("Up2") )
            {
                if (transform.position.y < 7)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
                    audio.Effect(Move);
                }
                Debug.Log(transform.position.y);
            }
            else if (Input.GetButtonDown("Down2"))
            {
                if (transform.position.y > 3)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
                    audio.Effect(Move);
                }
                Debug.Log(transform.position.y);
            }

        }

        

        if (GetComponent<BoxCollider>().enabled)
        {
            FanAnim.SetBool("Enchufao", true);
            WintAnim.SetBool("Viento", true);
            transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            WintAnim.SetBool("Viento", false);
            FanAnim.SetBool("Enchufao", false);
            transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (GetComponent<BoxCollider>().enabled)
        {
            if (other.gameObject.CompareTag("Bubble"))
            {
                Debug.Log("Bubel");
                if (other.gameObject.GetComponent<BubbleMovement>().Direction != SetDirectionTo) other.gameObject.GetComponent<BubbleMovement>().Direction = SetDirectionTo;
            }
        }
    }
}
