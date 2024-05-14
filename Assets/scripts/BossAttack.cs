using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public Transform[] spawnlocation;
    public GameObject bullet;
    public bool isAttacking=true;
    private int spawnpoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isAttacking)
        {
            spawnpoint = Random.Range(0, spawnlocation.Length);
            Debug.Log(spawnpoint);
            
            Instantiate(bullet, spawnlocation[spawnpoint].position,Quaternion.identity);
            isAttacking = false;
            Invoke("resetattack", 0.2f);
        }
    }
    void resetattack()
    {
        isAttacking =true;
    }
}
