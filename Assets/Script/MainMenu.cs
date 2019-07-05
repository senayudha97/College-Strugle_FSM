using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void playgame()
	{
		Player.health = 10;
		SceneManager.LoadScene ("Stage1");
	}

	public void exitgame()
	{
		SceneManager.LoadScene ("Menu");
	}

	public void Quit()
	{
		Debug.Log ("Quit!!");
		Application.Quit();
	}
}
