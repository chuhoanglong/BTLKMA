using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    public void StartGame()
    {
        Application.LoadLevel("Game");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Menu()
    {
        Application.LoadLevel("Menu");
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
