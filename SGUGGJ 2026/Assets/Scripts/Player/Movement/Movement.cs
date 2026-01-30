using System.Collections;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5;
    public Rigidbody2D rb;

    private bool IsKnockedBack;
    void FixedUpdate()
    {
        if (IsKnockedBack == false)
        {


            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            rb.linearVelocity = new Vector2(horizontal, vertical) * speed;

            if (vertical > 0)
            {

                transform.rotation = Quaternion.Euler(0, 0, 90);
            }
            else if (vertical < 0)
            {

                transform.rotation = Quaternion.Euler(0, 0, -90);
            }
            if (horizontal > 0)
            {


                transform.rotation = Quaternion.Euler(0, 0, 0);

            }
            else if (horizontal < 0)
            {

                transform.rotation = Quaternion.Euler(0, 0, 180);
            }

        }
    }


    public void KnockBack(Transform enemy,float force,float stunTime)
    {

        IsKnockedBack = true;
        Vector2 direction = (transform.position - enemy.position).normalized;
        rb.linearVelocity = direction*force;
        StartCoroutine(KnockBackCounter(stunTime));
    }
    
    IEnumerator KnockBackCounter(float stunTime)
    {
        yield return new WaitForSeconds(2);
        rb.linearVelocity = Vector2.zero;
        IsKnockedBack= false;

    }
}


