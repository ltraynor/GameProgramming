using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	public float timeBetweenBullets = 0.15f;

	AudioSource gunSound;
	LineRenderer bulletLine;
	Ray shootRay;
	float timer;

	// Use this for initialization
	void Start () {
		timer = 0f;
		bulletLine = GetComponent<LineRenderer> ();
		gunSound = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (Input.GetButton ("Fire1") && timer >= timeBetweenBullets) {
			Shoot(); 
		} else { 
			DisableEffects();
		}
	
	}

	void DisableEffects () {
		bulletLine.enabled = false;
	}

	void Shoot () {
		timer = 0f;
		bulletLine.enabled = true;

		gunSound.Play ();

		shootRay.origin = transform.position;
		shootRay.direction = transform.forward;

		RaycastHit shootHit;

		bulletLine.SetPosition (0, transform.position);
	
		if (Physics.Raycast (shootRay, out shootHit)) {
			bulletLine.SetPosition (1, shootHit.point);
		} else {
			bulletLine.SetPosition(1, shootRay.origin + shootRay.direction * 1000);
		}
	}
}
