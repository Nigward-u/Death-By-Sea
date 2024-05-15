using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
//using UnityEditor.VersionControl;
using UnityEngine;

public class enemybehavior : MonoBehaviour
{
    public GameObject pointA, pointB, RayOrigin, attackrange/*,Player*/;
    private Rigidbody2D rb;
    private Animator a;
    private Transform currentpos;
    public float speed;
    public SpriteRenderer spriteRenderer;
    private Vector2 raydir;
    public bool ReadyToAttack, IsAttacking;
    //public Health health;
    public Animator anim;

    public LayerMask player;
    // Start is called before the first frame update
    void Start()
    {
        ReadyToAttack = true;
        IsAttacking = false;
        rb = GetComponent<Rigidbody2D>();
        currentpos = pointA.transform;
        //Player = GameObject.Find("player");
        //Health health =Player.GetComponent<Health>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("IsAttacking", false);
        if (IsAttacking == false)
        {
            Vector2 point = currentpos.position - transform.position;
            if (currentpos == pointA.transform)
            {
                rb.velocity = new Vector2(-speed, 0);

            }
            else
            {
                rb.velocity = new Vector2(speed, 0);



            }
            if (Vector2.Distance(transform.position, currentpos.position) < 0.5f && currentpos == pointB.transform)
            {
                currentpos = pointA.transform;
                transform.localScale = new Vector3(-1, 1, 1);
            }
            if (Vector2.Distance(transform.position, currentpos.position) < 0.5f && currentpos == pointA.transform)
            {
                currentpos = pointB.transform;
                transform.localScale = new Vector3(1, 1, 1);
            }
        }


        if (IsAttacking)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            Invoke("attackReset", 1f);
            anim.SetBool("IsAttacking", true);
        }
    }

    void attackReset()
    {
        IsAttacking = false;
        ReadyToAttack = true;
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

    }

    //public void attack()
    //{
    //    //attack animation
    //    health.health--;
    //}


}