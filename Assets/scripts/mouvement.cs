using Unity.VisualScripting;
//using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.UI;

public class mouvement : MonoBehaviour
{
    public float jumpForce = 10f; // The force applied to make the player jump
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    //private SpriteRenderer spriteRenderer;
    
    public LayerMask groundLayer;
    public bool isGrounded;
    public Transform respawnpoint;
    public Health healthscript;
    private Vector3 previousPosition; // Store the previous position of the player
    public SpriteRenderer spriteRenderer;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //spriteRenderer = GetComponent<SpriteRenderer>();
    }
    Vector2 movement = Vector2.zero;
    void Update()
    {
        
        Vector2 movement = Vector2.zero;

        var x = Input.GetAxis("Horizontal");
        transform.Translate(new Vector2(x, 0) * moveSpeed * Time.deltaTime);
        
        if(x < 0)
        {
            //flip(true);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if(x > 0)
        {
           // flip(false); 
            transform.localScale = new Vector3(1, 1, 1);

        }


        // Check if the ray hits something on the ground layer


        // Now you can use the isGrounded flag to control player actions such as jumping.

        if (Input.GetKeyDown(KeyCode.W)) {
            Debug.Log("3");
                Jump();
            }
        
    }
    void Jump()
    {
            Debug.Log("1");
        if (isGrounded)
        {
            Debug.Log("2");
        rb.AddForce(Vector2.up * jumpForce);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("void"))
        {
            this.transform.position=respawnpoint.position;
            healthscript.health -= 1;
        }
    }
    public void flip(bool fliptype)
    {
        spriteRenderer.flipX = fliptype;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
