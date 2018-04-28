using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;//import Scene


public class DeathMenu : MonoBehaviour {

    public Text scoreText;


    void Start()
    {
        gameObject.SetActive(false);
    }
	
	void Update () {
		
	}

    public float ToggleEndMenu(float score)
    {
        gameObject.SetActive(true);
        scoreText.text = ((int)score).ToString();
        return score;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
