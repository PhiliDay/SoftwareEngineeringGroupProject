using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class behaviour3d : MonoBehaviour {

	public GameObject head;
	public GameObject antenna;
	public int speed = 10;
	bool onGround;
	float incrementTime = 0.3f;
	float incrementBy = 1;
	float counter = 0;
	double time =0;


	void Start(){
	}

	void OnCollisionStay(){
		onGround = true;
	}

	void FixedUpdate(){
		float h = 15;
		float k = counter%33;
		if (counter<52.1){
			if(k<15){
				GetComponent<Rigidbody>().AddForce(Vector3.left * speed * h);
			}
			if(k>12){
				GetComponent<Rigidbody>().AddForce(Vector3.right * speed * h);
			}
		}
		else{
			GetComponent<Rigidbody>().angularDrag = 20;
		}

	}

	private void Update(){
		Vector3 above = new Vector3(0,7.5f,0);
		Vector3 above1 = new Vector3(-1,14,0);

		head.transform.position = transform.position+above;
		antenna.transform.position = transform.position+above1;
		time+=Time.deltaTime;
		while(time>incrementTime){
			time-=incrementTime;
			counter+=incrementBy;
		}
	}
}