using UnityEngine;

public class AttackArea : MonoBehaviour
{


    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject Go = collision.gameObject;
        Destroy(Go);
    }
}
