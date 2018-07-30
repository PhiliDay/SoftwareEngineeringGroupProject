using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class how_to_play_next : MonoBehaviour {

	[SerializeField] GameObject thisPanel;
	[SerializeField] GameObject nextPanel;

	public void Start() {
		nextPanel.gameObject.SetActive(false);
	}

	public void SubmitButtonPress() {
		thisPanel.gameObject.SetActive(false);
		nextPanel.gameObject.SetActive(true);
	}
}
