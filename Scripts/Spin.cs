using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour {
	public float speed;
	private int direction = -1;
	private Vector3 vec = new Vector3(0f, 0f, 1f);

	// Update is called once per frame
	void Update () {
		if (transform.rotation.eulerAngles.z < 290 && transform.rotation.eulerAngles.z > 270) {
			direction = -1;
		}
		if (transform.rotation.eulerAngles.z < 130 && transform.rotation.eulerAngles.z > 110) {
			direction = 1;
		}
		transform.Rotate (vec, direction * speed * Time.deltaTime);
	}
}