using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DragButton : MonoBehaviour {
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

	[SerializeField] GameObject Item1;
	[SerializeField] GameObject Item2;
	[SerializeField] GameObject Item3;
	[SerializeField] GameObject Item4;
	[SerializeField] GameObject Item5;
	[SerializeField] GameObject Item6;
	[SerializeField] GameObject Item7;
	[SerializeField] GameObject Item8;
	[SerializeField] GameObject Item9;
	[SerializeField] GameObject Item10;
	[SerializeField] GameObject Item11;

	[SerializeField] GameObject DoorParent;
	[SerializeField] GameObject Door;
	[SerializeField] GameObject Canvas;

	public void SubmitButtonPress() {
		if (Item1.transform.parent.gameObject == Slot1.transform.gameObject &&
		    Item2.transform.parent.gameObject == Slot2.transform.gameObject &&
			Item3.transform.parent.gameObject == Slot3.transform.gameObject &&
			Item4.transform.parent.gameObject == Slot4.transform.gameObject &&
			Item5.transform.parent.gameObject == Slot5.transform.gameObject &&
			Item6.transform.parent.gameObject == Slot6.transform.gameObject &&
			Item7.transform.parent.gameObject == Slot7.transform.gameObject &&
			Item8.transform.parent.gameObject == Slot8.transform.gameObject &&
			Item9.transform.parent.gameObject == Slot9.transform.gameObject &&
			Item10.transform.parent.gameObject == Slot10.transform.gameObject &&
			Item11.transform.parent.gameObject == Slot11.transform.gameObject) {

			Debug.Log("WORKED");
			Canvas.gameObject.SetActive(false);
			DoorParent.gameObject.GetComponent<Animator>().enabled=true;
			Door.transform.gameObject.tag = "popped";
		}
	}

	IEnumerator waitSeconds() {
		yield return new WaitForSecondsRealtime (5);
		SceneManager.UnloadSceneAsync ("drag_drop");
	}
}
