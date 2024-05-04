using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack1 : MonoBehaviour
{
    public Animator animator;
    public Transform attackpoint;
    public LayerMask enemylayers;

    public int AttackDammage;
    public float attackrange = 0.5f;


    public bool isattacking = false;

    public float attackRate = 2f;
    float NextAttackTime = 0f;
    void Update()
    {
        if (Time.time >= NextAttackTime)
        {
            if (Input.GetMouseButton(0))
            {
                Attack();
                NextAttackTime = Time.time + 1f / attackRate;
                isattacking = true;
            }
        }

        isattacking = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!Input.GetKeyDown(KeyCode.Escape)) { return; }
        if (isattacking)
        {
            Debug.Log("he's doing dammage");
            Destroy(collision.gameObject);
        }
    }
    private void Attack()
    {
        animator.SetTrigger("attack");
        Collider2D[] hitenemies = Physics2D.OverlapCircleAll(attackpoint.position, attackrange, enemylayers);

        foreach (Collider2D enemy in hitenemies)
        {
            enemy.GetComponent<Enemies>().Takedammage(AttackDammage);

        }
    }
    private void OnDrawGizmosSelected()
    {
        if (attackpoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackpoint.position, attackrange);
    }
}
