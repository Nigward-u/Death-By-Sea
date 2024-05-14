using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletbehavior : MonoBehaviour
{

    void Update()
    {
        transform.position += new Vector3(0, -10,0) * Time.deltaTime;

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        {
            Debug.Log("t");
            if (other.tag == "destroy")
            {
                Debug.Log('d');
                Destroy(gameObject);
            }
        }
    }


}
