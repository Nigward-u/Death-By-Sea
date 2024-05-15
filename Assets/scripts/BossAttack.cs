using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public Transform[] spawnlocation;
    public GameObject bullet;
    public bool isAttacking = true;
    private int spawnpoint;
    public int nb_Bullets = 20;
    public bool isResting = false;
    public float attackDelay = 0.3f;
    public float reloadTime = 5f;
    public GameObject bubble;
    public Transform bubblepos;
    public bool spawnbubble=false;
    public int hp = 4;

    void Start()
    {
        StartCoroutine(AttackRoutine());
    }

    IEnumerator AttackRoutine()
    {
        while (true)
        {
            if (isAttacking && nb_Bullets > 0)
            {
                spawnpoint = Random.Range(0, spawnlocation.Length);
                Instantiate(bullet, spawnlocation[spawnpoint].position, Quaternion.identity);
                nb_Bullets--;
                yield return new WaitForSeconds(attackDelay);
                spawnbubble = true;
            }
            if (spawnbubble && nb_Bullets == 0)
            {
                Instantiate(bubble, bubblepos.position, Quaternion.identity);
                spawnbubble = false;
                
            }
            else if (nb_Bullets == 0 && !isResting)
            {
                isResting = true;
                isAttacking = false;
                yield return new WaitForSeconds(reloadTime);
                isAttacking = true;
                isResting = false;
                nb_Bullets = 20;
                
            }
            
            
            yield return null;
            if (hp == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
