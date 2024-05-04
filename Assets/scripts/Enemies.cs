using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public int Maxhealth;
    public int currenthealth;
    // Start is called before the first frame update
    void Start()
    {
        currenthealth = Maxhealth;
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
        Debug.Log("Enemie died");
        Destroy(gameObject);
    }

}
