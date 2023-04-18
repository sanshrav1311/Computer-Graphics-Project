using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
     public AudioSource cs;
     void Start()
     {
        cs = GameObject.FindGameObjectWithTag("mcs").GetComponent<AudioSource>();
     }
    public void PlayGame()
    {
        cs.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        cs.Play();
        Application.Quit();
    }
}
