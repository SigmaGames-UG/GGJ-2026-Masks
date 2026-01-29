using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    [SerializeField] public int health;
    [SerializeField] private Slider HealthSlider;
    public void TakeDamage(int damage)
    {
        health -= damage;
        HealthSlider.value = health;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }


}
