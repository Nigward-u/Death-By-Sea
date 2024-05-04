using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hama : MonoBehaviour
{
    public Transform[] points;
    public float speed;
    public float distance;
    public float currDistance;
    private void Awake()
    {
        currDistance = distance;
    }
    private void Update()
    {
        transform.Translate(Vector2.right * speed);
        currDistance-= Time.deltaTime;
        if(currDistance < 0)
        {
            speed*=-1;
        }
    }
}
