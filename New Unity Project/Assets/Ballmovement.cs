using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Ballmovement : MonoBehaviour {
 
	//make ourselves a rigid body
	Rigidbody physicsBody; 

	//multiply input by this number and that is how fast the sphere moves
	public int Speed = 90;
	private int rawScore;	//the score
	//these are the text variables
	public Text displayedScore; //score
	public Text winText;	//winning display
	public Text loseText;	//losing display (not added yet)
	//have you won yet?
	bool wonYet;
	bool lostYet; //have you lost yet?

	void Start () {
		//score starts at 0
		rawScore = 0;
		//give our ball a body
		physicsBody = GetComponent<Rigidbody>();
		//set the scoreboard (see below function)
		SetScoreBoard ();
		//if you happen to win...
		winText.text = "You Win!!!!"; //remains unactive until then
		winText.gameObject.SetActive (false);
		//same deal with losing...
		loseText.text = "You lose... :(";
		loseText.gameObject.SetActive (false);
		//you haven't won yet
		wonYet = false;
		lostYet = false;
	}
	
	// FixedUpdate is called once before physics calculations
	void FixedUpdate () {
		//this is so we can move
		float zMovement = Input.GetAxis ("Vertical"); 
		float xMovement = Input.GetAxis ("Horizontal");

		//multiply input by this number and that is how fast the sphere moves
		//int Speed = 90;

		float scaledXMovement = xMovement * Speed;
		float scaledZMovement = zMovement * Speed;

		//actually move the thing
		physicsBody.velocity = new Vector3(scaledXMovement,0,scaledZMovement);

		Vector3 playerPos = gameObject.transform.position;

		if ((playerPos.x > 45 || playerPos.x < -45 || playerPos.z > 45 || playerPos.z < -45) && wonYet != true)  {
			loseText.gameObject.SetActive(true);
			lostYet = true;
		}
	
	}


	//this is for collisions
	void OnTriggerEnter(Collider token) {
		//Destroy (token.gameObject);
		//increase your score
		rawScore++;
		//set the scoreboard again
		SetScoreBoard ();
		//object becomes false
		token.gameObject.SetActive(false);
		//if you have enough points to win...!!
		if (rawScore == 4 && lostYet != true) {
			winText.gameObject.SetActive(true);	//then you win
			wonYet = true;
		}


	}

	void SetScoreBoard () {
		displayedScore.text = "Score: " + rawScore.ToString ();
	}
}
