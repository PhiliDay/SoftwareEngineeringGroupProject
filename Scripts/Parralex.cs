using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parralex : MonoBehaviour {

	public Transform[] backgrounds; 		//Array of all the back and foregrounds to be parralexed
	private float[] parralexScales; 		//Proportion of the cameras movement to move the backgrounds by
	public float smoothing = 1;  		   //How smooth the parralex is going to be

	private Transform cam;                //Reference to main camera transform 
	private Vector3 previousCamPosition;    //Vector 3 has x,y,z - store the position of the camera in the previous frame

	//before start - it calls all the logic before the start function but after the game objects are set up
	void Awake() {
		cam = Camera.main.transform;
	}
		
	// Use this for initialization
	void Start () {
		previousCamPosition = cam.position;

		parralexScales = new float[backgrounds.Length];

		for(int i = 0; i < backgrounds.Length; i++){
			parralexScales[i] = backgrounds[i].position.z*-1;
		}	
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < backgrounds.Length; i++) {
			float parralex = (previousCamPosition.x - cam.position.x) * parralexScales [i];

			float backgroundTargetPosX = backgrounds [i].position.x + parralex;

			Vector3 backgroundTargetPos = new Vector3 (backgroundTargetPosX, backgrounds [i].position.y, backgrounds [i].position.z);

			backgrounds [i].position = Vector3.Lerp (backgrounds [i].position, backgroundTargetPos, smoothing * Time.deltaTime);
		}

		previousCamPosition = cam.position;
	}
}
