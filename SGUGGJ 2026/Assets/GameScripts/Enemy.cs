using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    private Transform target;
    [SerializeField] private GameObject ViewArea;
    public int damage = 1;
    
    void Start()
    {
        target = GameObject.FindGameObjectWithTag ("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {


        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Health health = collision.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }
    }

    
}
