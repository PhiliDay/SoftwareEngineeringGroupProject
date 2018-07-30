using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour {

		public void PlayGame()
		{
			Debug.Log ("BUTTONPLAY");
			SceneManager.LoadScene("background");
		}
		
		public void QuitGame()
		{
					Debug.Log("QUIT!");
					Application.Quit();
		}
}
