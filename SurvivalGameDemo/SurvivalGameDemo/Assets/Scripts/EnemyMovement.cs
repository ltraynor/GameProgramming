/////////////////////////////////////////////////////////////////
//Author: Logan Traynor
//Date: 9/28/15
//EnemyMovement.cs - script that defines the movement of the
//	enemy zombunny, which relentlessly advances on the player
////////////////////////////////////////////////////////////////

//import som things
using UnityEngine;
using System.Collections;

//overarching class
public class EnemyMovement : MonoBehaviour {

	//declare some variables
	public float movementSpeed = 0.33f;	//scalar to be applied to movement vector
	public Transform rotateTowardsPlayer;	//used to constantly track the player
	
	Rigidbody enemyRigidbody; // give our guy a Rigidbody
	Animator enemyAnimator;	//give him some animations
	
	// Use this for initialization
	void Start () {
		enemyRigidbody = GetComponent<Rigidbody>(); //activate the rigid body
		enemyAnimator = GetComponent<Animator> ();	//activate the animator
		rotateTowardsPlayer = transform; //activate the transform
	}


	// Update is called once per frame
	void Update () {

		//find the player's position every update
		Vector3 targetLocation = GameObject.Find("Player").transform.position;
		//attempting to make it move slower...
		float forwardMovement = 0.01f;
		//set the animator so it walks
		enemyAnimator.SetBool("IsWalking", true);
		//look at the players position always
		rotateTowardsPlayer.LookAt (targetLocation);

		//make the movement vectors
		Vector3 movement = forwardMovement * transform.forward;
		movement = movement.normalized * Time.deltaTime * movementSpeed;

		//move the enemy
		enemyRigidbody.MovePosition(transform.position + movement);
	}
}
