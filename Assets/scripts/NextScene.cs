using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public mouvement mvt;
    public attack1 atck;
   // public Animator anim;
    // Start is called before the first frame update
    private void Start()
    {
        //anim=GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Next Scene"))
        {
            mvt.enabled = false;
            atck.enabled = false;
           // anim.SetBool("Nextscene",true);
            Invoke("nextscene", 1f);
        }
    }
    public void nextscene()
    {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    // Update is called once per frame

}
