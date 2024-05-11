using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemybehavior : MonoBehaviour
{
    public GameObject pointA, pointB;
    private Rigidbody2D rb;
    private Animator a;
    private Transform currentpos;
    public float speed;
    public SpriteRenderer spriteRenderer;
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
            flip(true);

        }
        else { rb.velocity=new Vector2(speed,0);
            flip(false);
        }
        if(Vector2.Distance(transform.position, currentpos.position) < 0.5f && currentpos == pointB.transform)
        {
            currentpos = pointA.transform;
        }
        if (Vector2.Distance(transform.position, currentpos.position) < 0.5f && currentpos == pointA.transform)
        {
            currentpos = pointB.transform;
        }
    }
    public void flip(bool fliptype)
    {
        spriteRenderer.flipX = fliptype;
    }

}
