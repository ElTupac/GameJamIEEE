using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public static bool GamePaused = false;

    public GameObject pausemenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GamePaused)
            {
                resume();
            }
            else
            {
                pause();                
            }
        
        }    
    }

    public void resume()
    {
        pausemenuUI.SetActive(false);
        Time.timeScale = 1f; 
        GamePaused = false;
    }

    void pause()
    {
        pausemenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }

    public void resetDungeon()
    {
        //Resetear todo el dungeon o un nivel, definir eso
        //Time.timeScale = 1f;
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
