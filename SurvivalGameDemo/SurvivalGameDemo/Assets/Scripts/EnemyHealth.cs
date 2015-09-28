////////////////////////////////////////////////
//Author: Logan Traynor
//Date: 9/28/15
//EnemyHealth.cs - determines how much health 
//	an enemy has and how they take damage
////////////////////////////////////////////////

//import things
using UnityEngine;
using System.Collections;

//over-arching class
public class EnemyHealth : MonoBehaviour {

	//set the max health
	public int maxHealth = 30;
	//declare current health
	int currHealth;

	// Use this for initialization
	void Start () {
		//set the current health to the max health at the start of the game
		currHealth = maxHealth;
	}

	// Update is called once per frame
	//Function that defines how an enemy takes damage
	public void TakeDamage (int damage) {
		//subtract the damage dealt from your curret health
		currHealth = currHealth - damage;
	}
}
