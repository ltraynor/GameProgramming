using UnityEngine;
using System.Collections;

public class Ballmovement : MonoBehaviour {
 
	//make ourselves a rigid body
	Rigidbody physicsBody; 

	void Start () {

		physicsBody = GetComponent<Rigidbody>(); 
	}
	
	// FixedUpdate is called once before physics calculations
	void FixedUpdate () {
		//this is so we can move
		float zMovement = Input.GetAxis ("Vertical"); 
		float xMovement = Input.GetAxis ("Horizontal");

		//multiply input by this number and that is how fast the sphere moves
		int Speed = 90;

		float scaledXMovement = xMovement * Speed;
		float scaledZMovement = zMovement * Speed;

		//actually move the thing
		physicsBody.velocity = new Vector3(scaledXMovement,0,scaledZMovement); 

	
	}

	//this is for collisions
	void OnTriggerEnter(Collider token) { 
		token.gameObject.SetActive(false);

	}
}
