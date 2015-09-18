using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Ballmovement : MonoBehaviour {
 
	//make ourselves a rigid body
	Rigidbody physicsBody; 

	//multiply input by this number and that is how fast the sphere moves
	public int Speed = 90;
	private int rawScore;	//the score
	public Text displayedScore;
	public Text winText;

	void Start () {
		rawScore = 0;
		//void OnGUI() {
		//	GUI.Label(new Rect(0, 0, 100, 25), "Score: " + Score);
		//}
		physicsBody = GetComponent<Rigidbody>();
		SetScoreBoard ();
		winText.text = "You Win!!!!";
		winText.gameObject.SetActive (false);
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

	
	}


	//this is for collisions
	void OnTriggerEnter(Collider token) {
		//Destroy (token.gameObject);
		rawScore++;
		SetScoreBoard ();
		token.gameObject.SetActive(false);
		if (rawScore == 4) {
			winText.gameObject.SetActive(true);
		}

	}

	void SetScoreBoard () {
		displayedScore.text = "Score: " + rawScore.ToString ();
	}
}
