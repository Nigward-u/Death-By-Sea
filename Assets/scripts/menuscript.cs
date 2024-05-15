using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class menuscript : MonoBehaviour
{
   
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            
            Application.Quit();
        }
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void Quit()
    {
        Debug.Log("QUIT!!");
        Application.Quit();
    }

}
