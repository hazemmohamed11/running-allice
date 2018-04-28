using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {


  
	void Start () {

	}
	
	public void Update () {

	}

    public void play()
    {
        SceneManager.LoadScene("ds");

    }

    public void Quit()
    {

        Application.Quit();
    }
     
}
