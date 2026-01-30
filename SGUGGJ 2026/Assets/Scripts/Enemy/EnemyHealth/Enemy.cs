using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int damage = 10;
    private int KnockBackForce;
    public float stunTime;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            collision.gameObject.GetComponent<PlayerHealth>().ChangeHealth(-damage);
            collision.gameObject.GetComponent<Movement>().KnockBack(transform, KnockBackForce,stunTime);
        }
        
    }
}
