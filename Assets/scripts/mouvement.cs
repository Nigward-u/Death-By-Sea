using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.UI;

public class mouvement : MonoBehaviour
{
    public float jumpForce = 10f; // The force applied to make the player jump
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    //private SpriteRenderer spriteRenderer;
    private float raycastDistance = 0.1f;
    public LayerMask groundLayer;
    public bool isGrounded;
    public Transform respawnpoint;
    public Health healthscript;
    private Vector3 previousPosition; // Store the previous position of the player


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //spriteRenderer = GetComponent<SpriteRenderer>();
    }
    Vector2 movement = Vector2.zero;
    void Update()
    {
        
        Vector2 movement = Vector2.zero;

        // Handle arrow key input       
        if (Input.GetKey(KeyCode.A)||(Input.GetKey(KeyCode.LeftArrow)))
        {
            movement = Vector2.left * moveSpeed;
            rb.velocity = new Vector2(movement.x, rb.velocity.y);
            //spriteRenderer.flipX = true;
        }
        else if (Input.GetKey(KeyCode.D)||(Input.GetKey(KeyCode.RightArrow)))
        {
            movement = Vector2.right * moveSpeed;
            rb.velocity = new Vector2(movement.x, rb.velocity.y);

            // spriteRenderer.flipX = false;

        }
        Vector2 raycastOrigin = transform.position - new Vector3(0f, 0.30f, 0f); // Adjust the Y value as needed

        RaycastHit2D hit = Physics2D.Raycast(raycastOrigin, Vector2.down, raycastDistance, groundLayer);

        // Check if the ray hits something on the ground layer
        if (hit.collider != null)
        {
            // Player is grounded
            isGrounded = true;
            Debug.Log(isGrounded);
        }
        else
        {
            // Player is not grounded
            isGrounded = false;
        }
        Debug.DrawRay(raycastOrigin, Vector2.down * raycastDistance, Color.green);

        // Now you can use the isGrounded flag to control player actions such as jumping.
        if (isGrounded)
        {
            // Player is grounded, allow jumping
            if (Input.GetKey(KeyCode.UpArrow)||(Input.GetKey(KeyCode.W)))
            {
                Jump();
            }
        }
    }
    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("void"))
        {
            this.transform.position=respawnpoint.position;
            healthscript.health -= 1;
        }
    }
    private void LateUpdate()
    {
        previousPosition = transform.position;
    }
}
