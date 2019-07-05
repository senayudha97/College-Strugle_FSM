using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Susanoo : MonoBehaviour {

	public static int health = 20;	
	public GameObject milos,deathImpact;

	

	void OnTriggerEnter2D (Collider2D col){

		if (col.gameObject.tag.Equals ("book")){
			health -= 1;
			Debug.Log(health);
		}
		if (health <= 0)
		{
			Instantiate(deathImpact, transform.position, Quaternion.identity);	
			Destroy(milos);
		}
	}
}
