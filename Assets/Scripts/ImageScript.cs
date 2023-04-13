using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ImageScript : MonoBehaviour
{
    PlayerStats Player;
    Sprite gunImage;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        gunImage = Player.Gun2.GetComponent<Shooting>().img;
        gameObject.GetComponent<Image>().sprite = gunImage;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("f")){
            StartCoroutine(yep());
        }
    }
    IEnumerator yep(){
        yield return new WaitForSeconds(0.1f);
        gunImage = Player.Gun2.GetComponent<Shooting>().img;
        gameObject.GetComponent<Image>().sprite = gunImage;
    }
}
