using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameover : MonoBehaviour
{
    // Start is called before the first frame update
    void playAgain(){
        SceneManager.LoadScene(1);
    }
    void quit(){
        Application.Quit();
    }
}
