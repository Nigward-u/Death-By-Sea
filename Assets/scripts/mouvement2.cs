using UnityEngine;
using System.Collections;
public class mouvement2 : MonoBehaviour
{
    public float speed;
    

    // Use this for initialization
    void Start()
    {
        
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
    }
}