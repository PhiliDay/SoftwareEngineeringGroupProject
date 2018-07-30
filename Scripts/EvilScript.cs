using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EvilScript : MonoBehaviour {
	[SerializeField] GameObject Slot1;
	[SerializeField] GameObject Slot2;
	[SerializeField] GameObject Slot3;
	[SerializeField] GameObject Slot4;
	[SerializeField] GameObject Slot5;
	[SerializeField] GameObject Slot6;
	[SerializeField] GameObject Slot7;
	[SerializeField] GameObject Slot8;
	[SerializeField] GameObject Slot9;
	[SerializeField] GameObject Slot10;

	[SerializeField] GameObject Item1;
	[SerializeField] GameObject Item3;
	[SerializeField] GameObject Item4;
	[SerializeField] GameObject Item5;
	[SerializeField] GameObject Item7;
	[SerializeField] GameObject Item8;
	[SerializeField] GameObject Item10;
	[SerializeField] GameObject SALLE;

	[SerializeField] GameObject Canvas;
	private int correctItems;


	public void SubmitButtonPress() {
		correctItems = 0;
		if (Item1.transform.parent.gameObject == Slot1.transform.gameObject) {
			makeGreen (Item1);
		}
		if (Slot2.transform.childCount == 1 && Slot2.transform.GetChild(0).tag == "robot") {
			makeGreen (Slot2.transform.GetChild(0).gameObject);
		}
		if (Item3.transform.parent.gameObject == Slot3.transform.gameObject) {
			makeGreen (Item3);
		}
		if (Item4.transform.parent.gameObject == Slot4.transform.gameObject) {
			makeGreen (Item4);
		}
		if (Item5.transform.parent.gameObject == Slot5.transform.gameObject) {
			makeGreen (Item5);
		}
		if (Slot6.transform.childCount == 1 && Slot6.transform.GetChild(0).tag == "robot") {
			makeGreen (Slot6.transform.GetChild(0).gameObject);
		}
		if (Item7.transform.parent.gameObject == Slot7.transform.gameObject) {
			makeGreen (Item7);
		}
		if (Item8.transform.parent.gameObject == Slot8.transform.gameObject) {
			makeGreen (Item8);
		}
		if (Slot9.transform.childCount == 1 && Slot9.transform.GetChild(0).tag == "robot") {
			makeGreen (Slot9.transform.GetChild(0).gameObject);
		}
		if (Item10.transform.parent.gameObject == Slot10.transform.gameObject) {
			makeGreen (Item10);
		}

		if (correctItems != 10) {
			SALLE.GetComponent<behaviour> ().removeCoinScore ();
		}

		if (correctItems == 10) {
			
			Debug.Log("WORKED");
			StartCoroutine (waitSeconds ());
		}
	}

	private void makeGreen(GameObject item) {
		Image image = item.GetComponent<Image> ();
		image.color = Color.green;
		correctItems++;
	}

	IEnumerator waitSeconds() {
		yield return new WaitForSeconds (1);
		SALLE.GetComponent<behaviour> ().stopLives ();
		Canvas.gameObject.SetActive(false);
	}
}