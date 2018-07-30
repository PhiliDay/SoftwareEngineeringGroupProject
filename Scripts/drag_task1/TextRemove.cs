using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextRemove : MonoBehaviour {
	public static Text finishing_text;

	void Start() {
		finishing_text = GetComponent<Text> ();
		finishing_text.enabled = false;
	}
}
