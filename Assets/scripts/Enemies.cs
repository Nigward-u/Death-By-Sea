using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{

    public int Maxhealth;
    public int currenthealth;
    public Animator anim;
    public Rigidbody2D body;
    public enemybehavior enemy;
    public GameObject enemyattack;
    // Start is called before the first frame update
    void Start()
    {
        currenthealth = Maxhealth;
        anim=GetComponentInChildren<Animator>();
        body =GetComponentInChildren<Rigidbody2D>();

    }
    public void Takedammage(int damage)
    {
        currenthealth -= damage;
        Debug.Log("dammage taken:" + damage);

        if (currenthealth <= 0)
        {
            Die();

        }
    }
    void Die()
    {
        //dying annimation
        enemyattack.SetActive(false);
        anim.SetBool("IsAttacking", false);
        anim.SetBool("IsDead", true);
        enemy.enabled = false;
        body.bodyType=RigidbodyType2D.Static;
        this.GetComponent<BoxCollider2D>().enabled = false;
        //transform.position = new Vector3(1, 0.27f, 1);
        //Debug.Log("Enemie died");      
        this.enabled = false;
    }

}
