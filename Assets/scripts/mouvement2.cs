using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class mouvement2 : MonoBehaviour
{
    Health health;
    public float speed;
    public waterBehavior w1, w2;
    public GameObject boss;
    public GameObject pausemenu;

    // Use this for initialization
    void Start()
    {
        health = GetComponent<Health>();
        resume();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveDirection = new Vector2 (0,0);
        var vertical = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");

        if (horizontal > 0)
        {
            moveDirection.x = 1;
           
        }
        else if (horizontal < 0)
        {
            moveDirection.x = -1;
           
        }
        else if (vertical > 0)
        {
            moveDirection.y = 1;
           
        }
        else if (vertical < 0)
        {
            moveDirection.y = -1;
           
        }
        transform.Translate(moveDirection * speed * Time.deltaTime);
        pause();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="bullet") {
            health.health--;
        
        }
        if (collision.tag == "bubble")
        {
            Debug.Log(-1);
            boss.GetComponent<BossAttack>().hp--;
            w1.resetpos();
            w2.resetpos();
        }
        if(collision.tag == "Hand")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
    }
    void pause()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            pausemenu.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
        }
    }
    public void resume()
    {
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.Locked;

    }
}