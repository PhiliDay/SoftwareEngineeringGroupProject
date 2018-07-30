using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageRemove : MonoBehaviour {
	public static Image finishing_screen;

	void Start() {
		finishing_screen = GetComponent<Image>();
		finishing_screen.enabled = false;
	}
}
