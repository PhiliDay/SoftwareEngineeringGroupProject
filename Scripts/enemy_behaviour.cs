using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class enemy_behaviour : MonoBehaviour {

	public int EnemySpeed = 5;
	public int EnemyDirection;
	private Vector3 beginningPos;
	private Rigidbody enemyBody;

	void Start(){
		beginningPos = gameObject.transform.position;
		enemyBody = gameObject.GetComponent<Rigidbody> ();
		enemyBody.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ;

	}

	// Update is called once per frame
	void FixedUpdate () {
		enemyBody.AddForce(Vector3.left*EnemySpeed*2);

	}

	void OnTriggerEnter(Collider other){

		if (other.gameObject.CompareTag ("evilbreak")) {
			enemyBody.transform.position = beginningPos;
		}
	}

}
