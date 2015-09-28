using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	public float movementSpeed = 3f;
	public float turnSpeed = 100f;
	public Transform myTransform;
	
	Rigidbody enemyRigidbody;
	Animator enemyAnimator;
	
	// Use this for initialization
	void Start () {
		enemyRigidbody = GetComponent<Rigidbody>();
		enemyAnimator = GetComponent<Animator> ();
		myTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 targetLocation = GameObject.Find("Player").transform.position;

		float forwardMovement = 0.1f;//Input.GetAxis("Vertical");

		if (forwardMovement == 0) {
			enemyAnimator.SetBool("IsWalking", false);
		} else {
			enemyAnimator.SetBool("IsWalking", true);
		}

		myTransform.LookAt (targetLocation);

		Vector3 movement = forwardMovement * transform.forward;
		movement = movement.normalized * Time.deltaTime * movementSpeed;

		enemyRigidbody.MovePosition(transform.position + movement);
	}
}
