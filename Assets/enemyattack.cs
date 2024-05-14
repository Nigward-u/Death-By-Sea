using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyattack : MonoBehaviour
{
    public enemybehavior enemy;
    public GameObject Player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            if (enemy.ReadyToAttack)
            {

                Health health = collision.GetComponent<Health>();
                health.health--;
                enemy.IsAttacking = true;
            }

            //enemy.attack();
        }
    }
}