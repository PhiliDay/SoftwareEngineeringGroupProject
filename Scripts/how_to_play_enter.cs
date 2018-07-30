using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class how_to_play_enter : MonoBehaviour {

	[SerializeField] GameObject Canvas;

	public void SubmitButtonPress() {
		Canvas.gameObject.SetActive(false);
	}
}
