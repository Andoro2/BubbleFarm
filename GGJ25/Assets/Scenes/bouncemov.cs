using UnityEngine;

public class bouncemov : MonoBehaviour
{
    
    Rigidbody rig_;
    Vector2 veloActu;

    [SerializeField] private float initialVelocity = 4f;
    // Start is called before the first frame update
    void Start()
    {
        rig_ = GetComponent<Rigidbody>();
        float xVelocity = Random.Range(1, 10);
        float yVelocity = Random.Range(1, 10); 
        veloActu = new Vector2(Time.deltaTime * xVelocity,
                                        Time.deltaTime * yVelocity);
    }

    // Update is called once per frame
    private void Update()
    {
        
        rig_.velocity = veloActu;
        transform.Translate(new Vector3(veloActu.x,veloActu.y, 0));

        if(transform.position.x >= 43.9f || transform.position.x <= -53.6f)
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
                if(hit.transform.gameObject == gameObject)
                {
                    Destroy(this.gameObject);
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


