using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class garbagemove : MonoBehaviour {

	Rigidbody GarbageTruck;
	public float Speed = 1.5f;
	[SerializeField] GameObject SALLE;

	// Use this for initialization
	void Start () {
		GarbageTruck = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		GarbageTruck.velocity = transform.forward * Speed;
	}

	void OnTriggerEnter(Collider other){

		if (other.gameObject.CompareTag ("garbage")) {
			SALLE.GetComponent<behaviour> ().addToTrashScore ();

			Destroy (other.gameObject);
		}
	}

}



