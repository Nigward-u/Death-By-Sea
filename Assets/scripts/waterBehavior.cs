using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class waterBehavior : MonoBehaviour
{
    public bool left;
    float x =- 0.2f;
    Vector3 startpos;
    public Health health ;
    void Start()
    {
        if (left)
        {
            startpos = new Vector3 (-6.719f , -0.3000f, -0.299f);
            x *= -1;
        }
        else
        {
            startpos = new Vector3(7.5999999f, 0.100000001f, -0.29936859f);
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(x,0,0)*Time.deltaTime;
        
    }
    public void resetpos()
    {
        transform.position = startpos;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Player")
        {
            Time.timeScale = 0;
            health.health = 0;
        }
    }
}
