using UnityEngine;

public class bouncemov : MonoBehaviour
{
    
    Rigidbody rig_;
    Vector2 veloActu;
    private SpriteRenderer face;
    public Sprite name;
    private bool hitted;

   public float initialVelocity;
    // Start is called before the first frame update
    void Start()
    {
        rig_ = GetComponent<Rigidbody>();
        float xVelocity = Random.Range(1, 10) ;
        float yVelocity = Random.Range(1, 10); 
        veloActu = new Vector2(Time.deltaTime * (xVelocity * initialVelocity),
                                        Time.deltaTime * (yVelocity * initialVelocity));
        face = transform.GetChild(0).GetComponent<SpriteRenderer>();

        hitted = false;
    }

    // Update is called once per frame
    private void Update()
    {
        
        rig_.velocity = veloActu;
        transform.Translate(new Vector3(veloActu.x,veloActu.y, 0));

        if(Mathf.Abs(veloActu.x)> initialVelocity)
        {
            veloActu.x = initialVelocity;
        }

        if (Mathf.Abs(veloActu.y) > initialVelocity)
        {
            veloActu.y = initialVelocity;
        }

        if (transform.position.x >= 43.9f || transform.position.x <= -53.6f)
        {
            veloActu.x *= -1.0f;
            //transform.position = (new Vector3(transform.position.x * -1, veloActu.y, 0));
        }

        if (transform.position.y >= 28.8f || transform.position.y <= -17.7f)
        {
            veloActu.y *= -1.0f;
            //transform.position = (new Vector3(veloActu.x, tranform.position.y * -1, 0));
        }

        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if(hit.transform.gameObject == gameObject && !hitted)
                {
                    hitted = true;
                    face.sprite = name;
                    transform.GetChild(0).GetComponent<Animation>().Stop();
                    transform.GetChild(0).rotation = Quaternion.identity;
                    transform.GetChild(0).localScale = new Vector3(3, 3, 3);
                }
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        veloActu.x *= -1.0f;
        veloActu.y *= -1.0f;
    }
}


