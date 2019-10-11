using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ChangeScene : MonoBehaviour {

	// Update is called once per frame
	public void ChangeToPlay () {
        //Application.LoadLevel ("PlayScene");
        SceneManager.LoadScene("PlayScene");
		
	}
	public void ChangeToChoose () {
        //Application.LoadLevel ("CharacterScene");
        SceneManager.LoadScene("CharacterScene");

	}
	public void ChangeToColor () {
        //Application.LoadLevel ("ColorScene");
        SceneManager.LoadScene("ColorScene");

	}
	public void ChangeToStart () {
        //Application.LoadLevel ("StartScene");
        SceneManager.LoadScene("StartScene");
	}
	public void Quit()
	{
		Application.Quit();
	}
}
