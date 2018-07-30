using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CoinScript : MonoBehaviour {
	[SerializeField] GameObject Slot1;
	[SerializeField] GameObject Slot2;
	[SerializeField] GameObject Slot3;
	[SerializeField] GameObject Slot4;
	[SerializeField] GameObject Slot5;
	[SerializeField] GameObject Slot6;

	[SerializeField] GameObject Item1;
	[SerializeField] GameObject Item2;
	[SerializeField] GameObject Item3;
	[SerializeField] GameObject Item4;
	[SerializeField] GameObject Item5;
	[SerializeField] GameObject Item6;

	[SerializeField] GameObject SALLE;
	[SerializeField] GameObject Canvas;
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
		if (Item4.transform.parent.gameObject == Slot4.transform.gameObject) {
			makeGreen (Item4);
		}
		if (Item5.transform.parent.gameObject == Slot5.transform.gameObject) {
			makeGreen (Item5);
		}
		if (Item6.transform.parent.gameObject == Slot6.transform.gameObject) {
			makeGreen (Item6);
		}

		if (correctItems != 6) {
			SALLE.GetComponent<behaviour> ().removeCoinScore ();
		}

		if (correctItems == 6) {
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
		Canvas.gameObject.SetActive(false);
	}
}
