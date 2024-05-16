using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int NumOfhearts;

    public Image[] hearts;
    public Sprite fullhearts;
    public Sprite emptyhearts;

    public GameObject deadmenu;

    //public Animator anim;

    //private void Start()
    //{
            //anim = GetComponent<Animator>();
    //}
    private void Update()
    {
        if (health > NumOfhearts)
        {
            health = NumOfhearts;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullhearts;
            }
            else
            {
                hearts[i].sprite = emptyhearts;
            }
            if (i < NumOfhearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
        if (health == 0)
        {
            //anim.SetBool("dead", true);
            deadmenu.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("heart"))
        {
            Destroy(collision.gameObject);
            if (health == NumOfhearts)
            {
                health += 1;
                NumOfhearts += 1;
            }
            else if (health < NumOfhearts)
            {
                health += 1;
            }

        }
    }
}
