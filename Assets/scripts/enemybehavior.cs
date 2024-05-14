using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class enemybehavior : MonoBehaviour
{
    public GameObject pointA, pointB,RayOrigin,attackrange;
    private Rigidbody2D rb;
    private Animator a;
    private Transform currentpos;
    public float speed;
    public SpriteRenderer spriteRenderer;
    private Vector2 raydir;
<<<<<<< Updated upstream
    public Health health;
=======
    public bool ReadyToAttack,IsAttacking;
    //public Health health;
    
>>>>>>> Stashed changes
    public LayerMask player;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentpos = pointA.transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point=currentpos.position-transform.position;
        if (currentpos == pointA.transform)
        {
            rb.velocity=new Vector2(-speed,0);
            
        }
        else { rb.velocity=new Vector2(speed,0);
            
            

        }
        if (Vector2.Distance(transform.position, currentpos.position) < 0.5f && currentpos == pointB.transform)
        {
            currentpos = pointA.transform;
            transform.localScale = new Vector3(-1,1,1);
        }
        if (Vector2.Distance(transform.position, currentpos.position) < 0.5f && currentpos == pointA.transform)
        {
            currentpos = pointB.transform;
            transform.localScale = new Vector3(1, 1, 1);
        }

        RaycastHit2D seeplayer = Physics2D.Raycast(RayOrigin.transform.position, raydir, 1f, player) ;
        Debug.DrawRay(RayOrigin.transform.position, raydir * 2f, color:Color.green);
        if (seeplayer.collider == null)
        {
            return;
        }
        else if (seeplayer.collider.CompareTag("Player") ){
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            Invoke("ResetMovement", 1f);
        }
        if (IsAttacking)
        {
            Invoke("attackReset", 1.5f);

        }

    }
    public void flip(bool fliptype)
    {
        spriteRenderer.flipX = fliptype;
    }
    void ResetMovement()
    {
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
<<<<<<< Updated upstream
    public void attack()
    {
        //attack animation
        health.health--;
=======

    //public void attack()
    //{
    //    //attack animation
    //    health.health--;
    //}
    void attackReset()
    {
        IsAttacking = false;
        ReadyToAttack = true;
>>>>>>> Stashed changes
    }
                    

}
