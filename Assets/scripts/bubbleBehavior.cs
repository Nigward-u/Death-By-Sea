using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbleBehavior : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player") {
            Invoke("removed", 0.1f);
        }
        
    }
    void removed()
    {
        Destroy(gameObject);
    }
}
