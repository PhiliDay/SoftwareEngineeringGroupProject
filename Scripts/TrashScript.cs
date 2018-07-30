using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TrashScript : MonoBehaviour {
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
	[SerializeField] GameObject Slot11;
	[SerializeField] GameObject Slot12;

	[SerializeField] GameObject Item1;
	[SerializeField] GameObject Item2;
	[SerializeField] GameObject Item3;
	[SerializeField] GameObject Item6;
	[SerializeField] GameObject Item7;
	[SerializeField] GameObject Item9;
	[SerializeField] GameObject Item12;
	[SerializeField] GameObject SALLE;

	[SerializeField] GameObject Canvas;
	[SerializeField] GameObject Truck;

	private int correctItems;

	public void SubmitButtonPress() {
		correctItems = 0;
		if (Item1.transform.parent.gameObject == Slot1.transform.gameObject) {
			makeGreen (Item1);
		}
		if (Item2.transform.parent.gameObject == Slot2.transform.gameObject) {
			makeGreen (Item2);
		}
		if (Item3.transform.parent.gameObject == Slot3.transform.gameObject) {
			makeGreen (Item3);
		}
		if (Slot4.transform.childCount == 1 && Slot4.transform.GetChild(0).tag == "true") {
			makeGreen (Slot4.transform.GetChild(0).gameObject);
		}
		if (Slot5.transform.childCount == 1&& Slot5.transform.GetChild(0).tag == "truck_drag") {
			makeGreen (Slot5.transform.GetChild(0).gameObject);
		}
		if (Item6.transform.parent.gameObject == Slot6.transform.gameObject) {
			makeGreen (Item6);
		}
		if (Item7.transform.parent.gameObject == Slot7.transform.gameObject) {
			makeGreen (Item7);
		}
		if (Slot8.transform.childCount == 1 && Slot8.transform.GetChild(0).tag == "truck_drag") {
			makeGreen (Slot8.transform.GetChild(0).gameObject);
		}
		if (Item9.transform.parent.gameObject == Slot9.transform.gameObject) {
			makeGreen (Item9);
		}
		if (Slot10.transform.childCount == 1 && Slot10.transform.GetChild(0).tag == "true") {
			makeGreen (Slot10.transform.GetChild(0).gameObject);
		}
		if (Slot11.transform.childCount == 1 && Slot11.transform.GetChild(0).tag == "truck_drag") {
			makeGreen (Slot11.transform.GetChild(0).gameObject);
		}
		if (Item12.transform.parent.gameObject == Slot12.transform.gameObject) {
			makeGreen (Item12);
		}

		if (correctItems != 12) {
			SALLE.GetComponent<behaviour> ().removeCoinScore ();
		}

		if (correctItems == 12) {
			Debug.Log("WORKED");

			StartCoroutine(waitSeconds ());
		}
	}

	private void makeGreen(GameObject item) {
		Image image = item.GetComponent<Image> ();
		image.color = Color.green;
		correctItems++;
	}

	IEnumerator waitSeconds() {
		yield return new WaitForSeconds (1);
		StartCoroutine (AudioFadeOut.FadeOut (Truck.GetComponent<AudioSource>(), 0.1f));
		Truck.GetComponent<AudioSource> ().enabled = true;
		Truck.GetComponent<AudioSource> ().Play ();

		Truck.GetComponent<garbagemove>().enabled = true;
		Canvas.gameObject.SetActive(false);

	}
}