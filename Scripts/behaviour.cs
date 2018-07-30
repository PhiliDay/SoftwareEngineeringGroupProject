 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class behaviour : MonoBehaviour {

    public GameObject headuno;
    public int speed = 1;
	public int coins;
	public int trash;
	private int lives;
    bool onGround;

	[SerializeField] GameObject LightCanvas;
	[SerializeField] GameObject LampCanvas;
	[SerializeField] GameObject PostBox1Canvas;
	[SerializeField] GameObject Popup2Canvas;
	[SerializeField] GameObject CoinCanvas;
	[SerializeField] GameObject TruckDrag;
	[SerializeField] GameObject TruckCanvas;
	[SerializeField] GameObject PopUp3Canvas;
	[SerializeField] GameObject PopUp4Canvas;
	[SerializeField] GameObject HowToPlayCanvas;
	[SerializeField] GameObject LevelCompleteCanvas;


	[SerializeField] GameObject EvilRobots;
	[SerializeField] List<GameObject> evilGuys;
	[SerializeField] GameObject Truck;

    public GameManager gameManager;
	private Rigidbody SalleBody;
	private bool livesDecreasing;
	public Text coinText;
	public Text trashText;
	public Text postText;
	public Text livesText;
	public Text endText;
	public Text endText1;
	public Text endText2;


	private Vector3 above = new Vector3 (0.04f,0.55f, 0f);
	private Vector3 level2Respawn;

    void Start () {
		PostBox1Canvas.gameObject.SetActive (false);
		LightCanvas.gameObject.SetActive(false);
		Popup2Canvas.gameObject.SetActive (false);
		CoinCanvas.gameObject.SetActive (false);
		TruckCanvas.gameObject.SetActive (false);
		TruckDrag.gameObject.SetActive (false);
		PopUp4Canvas.gameObject.SetActive (false);
		EvilRobots.gameObject.SetActive (false);
		GetComponent<AudioSource> ().enabled = false;
		Truck.GetComponent<AudioSource> ().enabled = false;
		livesDecreasing = true;

		SalleBody = GetComponent<Rigidbody> ();
		SalleBody.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ;
		coins = 4;
		trash = -1;
		lives = 9;
		addToCoinScore ();
		addToTrashScore ();
		removeLivesScore ();
  	}

    void OnCollisionStay()
    {
        onGround = true;
    }

  	void OnCollisionEnter(Collision other) {

        if(other.gameObject.CompareTag("levelup")){
			gameManager.CompleteLevel();
			Debug.Log("WALL TOUCHED");
			SalleBody.transform.Translate(22f, 1.42f, 0,Camera.main.transform);
			SalleBody.velocity = Vector3.zero;
		}

		if (other.gameObject.CompareTag("water")) {
			Debug.Log("WATER TOUCHED");
			removeLivesScore ();
			resetLives ();

			SalleBody.transform.Translate(-53f, 1.452f, 0f, Camera.main.transform);
		}

		if (other.gameObject.CompareTag("water1")) {
			Debug.Log("WATER TOUCHED");
			removeLivesScore ();
			resetLives ();

			SalleBody.transform.Translate(100f, 1.452f, 0f, Camera.main.transform);
		}

		if (other.gameObject.CompareTag("water3")) {
			Debug.Log("WATER TOUCHED");
			removeLivesScore ();
			resetLives ();

			SalleBody.transform.Translate(200f, 1.452f, 0f, Camera.main.transform);
		}

		if(other.gameObject.CompareTag("levelup2")){
			gameManager.CompleteLevel();
			Debug.Log("WALL TOUCHED");
			SalleBody.transform.Translate(11f, 1.42f, 0,Camera.main.transform);
			SalleBody.velocity = Vector3.zero;
			level2Respawn = SalleBody.transform.position;
		}

		if(other.gameObject.CompareTag("levelup3")){
			LevelCompleteCanvas.gameObject.SetActive(true);
			endLevel ();
			Debug.Log("WALL TOUCHED");
			StartCoroutine(waitSeconds());
		}

		if (other.gameObject.CompareTag("evilguy") && livesDecreasing == true){
			Debug.Log ("HELPME");
			removeLivesScore();
			resetLives ();
		}
  	}


	IEnumerator waitSeconds() {
		yield return new WaitForSeconds (6);
		SceneManager.LoadScene("Attempt_1");

	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag("Sphere")) {
			addToCoinScore();
			Debug.Log(" "+ coins);
			Destroy(other.gameObject);
		}

		if (other.gameObject.CompareTag("garbage")) {
			addToTrashScore();
			Debug.Log(" "+ trash);
			Destroy(other.gameObject);
		}

		if (other.gameObject.CompareTag("postbox")) {
			postText.text = "Welcome to Robotopia";
			Debug.Log("postbox");
		}

		if (other.gameObject.CompareTag ("streetlamp")) {
			Debug.Log ("StreetLamp");
			LightCanvas.gameObject.SetActive (true);
		}

		if (other.gameObject.CompareTag ("lightson")) {
			Debug.Log ("LightsOn");
			LampCanvas.gameObject.SetActive (true);
		}

		if (other.gameObject.CompareTag ("postbox")) {
			Debug.Log ("Postbox");
			Destroy (other.gameObject);
		}

		if (other.gameObject.CompareTag ("popup2boxcol")) {
			Debug.Log ("popup2boxcol");
			Popup2Canvas.gameObject.SetActive (true);
			Destroy (other.gameObject);
		}

		if (other.gameObject.CompareTag ("coininteract")) {
			Debug.Log ("coininteract");
			CoinCanvas.gameObject.SetActive (true);
			Destroy (other.gameObject);
		}

		if (other.gameObject.CompareTag ("truck")) {
			Debug.Log ("truck");
			Destroy (other.gameObject);
			TruckDrag.gameObject.SetActive (true);
		}

		if (other.gameObject.CompareTag ("truckspeech")) {
			Debug.Log ("truckbox");
			TruckCanvas.gameObject.SetActive (true);
			Destroy (other.gameObject);
		}

		if (other.gameObject.CompareTag ("popup3box")) {
			Debug.Log ("popup3box");
			PopUp3Canvas.gameObject.SetActive (true);
			Destroy (other.gameObject);
		}

		if (other.gameObject.CompareTag ("popupbox4")) {
			Debug.Log ("popup4box");
			PopUp4Canvas.gameObject.SetActive (true);
			Destroy (other.gameObject);
		}
			
		if (other.gameObject.CompareTag ("enableRobots")) {
			Debug.Log ("enableRObots");
			foreach (GameObject evilguy in evilGuys) {
				evilguy.GetComponent<enemy_behaviour>().enabled = true;
			}
				
			Destroy (other.gameObject);
		}

		if (other.gameObject.CompareTag ("boxcol")) {
			Debug.Log ("boxcol");
			EvilRobots.gameObject.SetActive (true);
			foreach (GameObject evilguy in evilGuys) {
				evilguy.GetComponent<enemy_behaviour>().enabled = false;
			}
			other.gameObject.GetComponent<BoxCollider>().enabled = false;
		}


	}



    void FixedUpdate () {
    
    	float h = Input.GetAxis ("Horizontal");

		if (LightCanvas.gameObject.activeSelf || PostBox1Canvas.gameObject.activeSelf || Popup2Canvas.gameObject.activeSelf || CoinCanvas.gameObject.activeSelf
			|| TruckCanvas.gameObject.activeSelf || TruckDrag.gameObject.activeSelf || PopUp3Canvas.gameObject.activeSelf
			|| PopUp4Canvas.gameObject.activeSelf || EvilRobots.gameObject.activeSelf || HowToPlayCanvas.gameObject.activeSelf) {
			SalleBody.velocity = Vector3.zero;
		}

		if(!LightCanvas.gameObject.activeSelf){
    			SalleBody.AddForce (Vector3.right * speed * h);

    			if (h == 0) {
    				SalleBody.angularVelocity = Vector3.zero;
    			}

	
      			if (Input.GetKey (KeyCode.UpArrow) && onGround == true) {
				GetComponent<AudioSource> ().enabled = true;
				GetComponent<AudioSource> ().Play ();
      				SalleBody.AddForce (0, 180, 0);
      				onGround = false;
      			}
		}

		if (SalleBody.velocity.magnitude > speed) {
			SalleBody.velocity = SalleBody.velocity.normalized * speed;
		}
    }

    private void Update()
    {
		headuno.transform.position = transform.position + above;

    }

	public void addToCoinScore(){
		coins++;
		coinText.text = "Coins: " + coins.ToString ();
	}

	public void addToTrashScore(){
		trash++;
		trashText.text = "Garbage: " + trash.ToString ();
	}

	public void endLevel(){
		if(lives == 0){
			endText.text = "Game Over!!!";
		}
		else{
		endText.text = "Game Complete!!!";
		}
		endText1.text = "Coins: " + coins.ToString ();
		endText2.text = "Garbage: " + trash.ToString ();
	}

	public void removeCoinScore(){
		coins--;
		coinText.text = "Coins: " + coins.ToString ();
	}

	public void removeLivesScore(){
		lives--;
		livesText.text = "Lives: " + lives.ToString ();
	}

	public void stopLives(){
		Debug.Log ("lives false");
		livesDecreasing = false;
	}

	public void resetLives(){
		if (lives == 0) {
			LevelCompleteCanvas.gameObject.SetActive(true);
			endLevel ();
			StartCoroutine(waitSeconds());

		}
	}
}
