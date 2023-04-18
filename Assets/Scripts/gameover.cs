using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;


public class gameover : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI score5;
    public int[] myNum = new int[6];
    int a,b,c,d,e,f;
    public AudioSource cs;

    // Start is called before the first frame update
    void Start()
    {
        cs = GameObject.FindGameObjectWithTag("mcs").GetComponent<AudioSource>();
        a = PlayerPrefs.GetInt("Score1", 0);
        b = PlayerPrefs.GetInt("Score2", 0);
        c = PlayerPrefs.GetInt("Score3", 0);
        d = PlayerPrefs.GetInt("Score4", 0);
        e = PlayerPrefs.GetInt("Score5", 0);
        f = PlayerPrefs.GetInt("Score", 0);
        myNum[0] = a;
        myNum[1] = b;
        myNum[2] = c;
        myNum[3] = d;
        myNum[4] = e;
        myNum[5] = f;
        Array.Sort(myNum);
        // score.text = GetComponent<TMPro.TextMeshProUGUI>().text;
        // Debug.Log(PlayerPrefs.GetInt("Score", 0));
        score.text=GetComponent<TMPro.TextMeshProUGUI>().text;
        score5.text=GetComponent<TMPro.TextMeshProUGUI>().text;
        // score.text = PlayerPrefs.GetInt("Score", 0).ToString();
    }
    void LateUpdate()
    {
        PlayerPrefs.SetInt("Score1", myNum[5]);
        PlayerPrefs.SetInt("Score2", myNum[4]);
        PlayerPrefs.SetInt("Score3", myNum[3]);
        PlayerPrefs.SetInt("Score4", myNum[2]);
        PlayerPrefs.SetInt("Score5", myNum[1]);
        // Debug.Log(a);
        // Debug.Log(myNum[1]);
        score.text = PlayerPrefs.GetInt("Score", 0).ToString();
        score5.text = myNum[5].ToString() + "\n" + myNum[4].ToString() + "\n" + myNum[3].ToString() + "\n" + myNum[2].ToString() + "\n" + myNum[1].ToString();
    }
    public void playAgain(){
        cs.Play();
        SceneManager.LoadScene(1);
    }
    public void quit(){
        cs.Play();
        Application.Quit();
    }
}



