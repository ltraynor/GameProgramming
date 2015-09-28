//////////////////////////////////////////////////////// 
//Author: Logan Traynor
//Date: 9/28/15
//PlayerAttack.cs - the script that defines the behavior 
//	of the player attack
//////////////////////////////////////////////////////////
 
//import things
using UnityEngine;
using System.Collections;

//overarching class
public class PlayerAttack : MonoBehaviour {

	//define some variables
	public float timeBetweenBullets = 0.15f;	//gun fire rate
	public int gunDamage = 10;	//damage the gun deals

	AudioSource gunSound;	//used for the audio of the gun
	LineRenderer bulletLine;	//used for the graphic of a "bullet" or "shot"
	Ray shootRay;	//also used for the bullet
	float timer;	//used to compare against timeBetweenBullets

	// Use this for initialization
	void Start () {
		timer = 0f;	//timer is set to 0
		bulletLine = GetComponent<LineRenderer> (); //render the bullet line
		gunSound = GetComponent<AudioSource> ();	//get the gun sound
	}


	// Update is called once per frame
	void Update () {

		//update the timer
		timer += Time.deltaTime;
		//if the player presses the fire button
		if (Input.GetButton ("Fire1") && timer >= timeBetweenBullets) {
			//then fire
			Shoot(); 
		} else { 
			//if not then dont show them shooting
			DisableEffects();
		}
	
	}

	//disable the bullet graphics
	void DisableEffects () {
		bulletLine.enabled = false;
	}


	//the shooting function
	void Shoot () {

		timer = 0f;	//reset timer
		bulletLine.enabled = true;	//enable the bullet graphics

		gunSound.Play ();	//play the gun shot sound

		//aim the ray in the correct direction
		shootRay.origin = transform.position;
		shootRay.direction = transform.forward;

		//this allows us to know whether the ray hit the target or not
		RaycastHit shootHit;

		//more graphics for the bullet that I dont fully understand.....
		bulletLine.SetPosition (0, transform.position);

		//if you hit something with a bullet
		if (Physics.Raycast(shootRay, out shootHit)) {
			//find out if the object you hit is an enemy / has health
			EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();
			//if it has health
			if (enemyHealth != null) {
				//then it takes damage!
				enemyHealth.TakeDamage(gunDamage);
			}
		}

		//if you hit something with a bullet
		if (Physics.Raycast (shootRay, out shootHit)) {
			//stop the bullet at that location
			bulletLine.SetPosition (1, shootHit.point);
		} else {
			//otherwise it goes off into infinity (but not really)
			bulletLine.SetPosition(1, shootRay.origin + shootRay.direction * 1000);
		}
	}
}
