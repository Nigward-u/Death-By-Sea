using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyattack : MonoBehaviour
{

    public enemybehavior enemy;
<<<<<<< Updated upstream
=======
    public GameObject Player;
    
>>>>>>> Stashed changes

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
<<<<<<< Updated upstream
            enemy.attack();
=======
            if (enemy.ReadyToAttack)
            {

                Health health = collision.GetComponent<Health>();
                health.health--;
                enemy.IsAttacking = true;
            }
            ;
            //enemy.attack();
>>>>>>> Stashed changes
        }
    }
}
