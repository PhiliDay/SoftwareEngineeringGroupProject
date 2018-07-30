using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Continue : MonoBehaviour {

	[SerializeField] GameObject Popup1;
	[SerializeField] GameObject Popup2;


	public void SubmitButtonPress() {
		Popup2.gameObject.SetActive (true);
		Popup1.gameObject.SetActive (false);
	}
}
