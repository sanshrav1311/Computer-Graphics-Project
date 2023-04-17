using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class gameover : MonoBehaviour
{
    public TextMeshProUGUI score;

    // Start is called before the first frame update
    void Start()
    {
        // score.text = GetComponent<TMPro.TextMeshProUGUI>().text;
        Debug.Log(PlayerPrefs.GetInt("Score", 0));
        score.text=GetComponent<TMPro.TextMeshProUGUI>().text;

        // score.text = PlayerPrefs.GetInt("Score", 0).ToString();
    }
    public void playAgain(){
        SceneManager.LoadScene(1);
    }
    public void quit(){
        Application.Quit();
    }
}
