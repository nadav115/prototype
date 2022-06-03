using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
   public void play()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void quit()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
