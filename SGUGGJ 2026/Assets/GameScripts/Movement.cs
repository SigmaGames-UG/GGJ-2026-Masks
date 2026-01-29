using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 0.5f;
    private Rigidbody2D rb;
    private Vector2 input;
    public float rotationSpeed = 200f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");


        input.Normalize();

        if (input.y > 0)
        {

            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else if (input.y < 0) { 
        
            transform.rotation = Quaternion.Euler(0, 0, -90);

        }
        if (input.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (input.x < 0) {
            transform.rotation = Quaternion.Euler(0, 0, -180);
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = input * speed;
    }

    
}
