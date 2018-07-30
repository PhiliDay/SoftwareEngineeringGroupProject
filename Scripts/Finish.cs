using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour {

	[SerializeField] GameObject LetterBox1Canvas;

	public void SubmitButtonPress() {
		LetterBox1Canvas.gameObject.SetActive (false);
	}
}
