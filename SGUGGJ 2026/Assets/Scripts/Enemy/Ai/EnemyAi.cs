using UnityEngine;
using UnityEngine.UI;

public class EnemyAi : MonoBehaviour
{

    public float speed;
    private Rigidbody2D rb;
    private Transform PJ;
    private int facingDirection = -1;

    private float chargeSpeed = 10;
    public Slider progressBar;
    public bool PlayerInside = false;

    

     void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

     void Update()
    {
        

        if (PlayerInside)
        {

            progressBar.value += chargeSpeed * Time.deltaTime;

            if (progressBar.value >= 100)
            {
                Chase();
            }

        }
        else {


            progressBar.value -= chargeSpeed * Time.deltaTime;

        }
    }

    void Chase()
    {

        
        if (PJ.position.x > transform.position.x && facingDirection == -1 || PJ.position.x < transform.position.x && facingDirection == 1)
        {
            Flip();
        }
        Vector2 direction = (PJ.position - transform.position).normalized;
        rb.linearVelocity = direction * speed;

    }
    void Flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y , transform.localScale.z);


    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (PJ == null)
            {
                PJ = other.transform;

            }
            PlayerInside = true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            rb.linearVelocity = Vector2.zero;
            PlayerInside = false;
        }
    }
}
