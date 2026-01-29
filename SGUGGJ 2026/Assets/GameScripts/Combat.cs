using UnityEngine;
using UnityEngine.Rendering;

public class Combat : MonoBehaviour
{
    private GameObject attackArea = default;

    private bool attacking = false;

    private float attackTime = 0.50f;
    private float timer = 0f;
    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {

            attack();
        }


        if (attacking)
        {

            timer += Time.deltaTime;
           if (timer>= attackTime)
            {

                timer = 0;
                attacking = false;
                attackArea.SetActive(attacking);
            }
        }
    }



    private void attack()
    {

        attacking = true;
        attackArea.SetActive(attacking);
    }

    
}




