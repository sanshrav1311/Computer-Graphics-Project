using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu1 : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public AudioSource cs;

    void Start()
    {
        cs = GameObject.FindGameObjectWithTag("mcs").GetComponent<AudioSource>();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            // cs.Play();
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }


    public void Pause()
    {
        // cs.Play();
        Cursor.lockState = CursorLockMode.None;
        pauseMenuUI.SetActive(true);
        Time.timeScale=0f;
        GameIsPaused = true;
    } 

    public void Resume()
    {
        // cs.Play();
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenuUI.SetActive(false);
        Time.timeScale=1f;
        GameIsPaused = false;
    }

    public void Quit()
    {
        cs.Play();
        Application.Quit();
    }

    public void playSound(){
        cs.Play();
    }
}
