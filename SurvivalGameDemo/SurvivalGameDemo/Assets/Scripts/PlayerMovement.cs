using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float movementSpeed = 10f;
	public float turnSpeed = 100f;

	Rigidbody playerRigidbody;
	Animator playerAnimator;

	// Use this for initialization
	void Start () {
		playerRigidbody = GetComponent<Rigidbody>();
		playerAnimator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		float forwardMovement = Input.GetAxis("Vertical");
		float turnMovement = Input.GetAxis("Horizontal");

		Debug.Log (forwardMovement);
		//Debug.Log (turnMovement);

		if ((forwardMovement == 0) && (turnMovement == 0)) {
			playerAnimator.SetBool ("IsWalking", false);
		} else {
			playerAnimator.SetBool ("IsWalking", true);
		}


		Vector3 movement = forwardMovement * transform.forward;
		movement = movement.normalized * Time.deltaTime * movementSpeed;

		playerRigidbody.MovePosition(transform.position + movement);

		float currRotation = transform.rotation.eulerAngles.y;
		float targetRotation = currRotation + turnMovement * Time.deltaTime * turnSpeed;
		Quaternion newRotation = Quaternion.Euler (new Vector3 (0,targetRotation,0));
		playerRigidbody.MoveRotation(newRotation);
	}
}
