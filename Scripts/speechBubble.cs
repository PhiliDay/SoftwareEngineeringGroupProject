using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class speechBubble : MonoBehaviour {

	public Image bubble;
	public Image bubble2;

	public Camera cam;

	private void Update () {
		bubble.transform.position = cam.WorldToScreenPoint (this.transform.position);
		bubble2.transform.position = cam.WorldToScreenPoint (this.transform.position);

	}
}
