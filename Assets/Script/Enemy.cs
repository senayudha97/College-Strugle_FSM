﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public int health = 10;
	Animator anim;
	bool IsDead;
	public GameObject deathEffect;
		
	public void TakeDamage (int damage)
	{
		health -= damage;
		Debug.Log(health);

		if	(health <= 0)
		{
			Die();
			Debug.Log("Enemy Mati");
		}
	}

	void Die()
	{
		Instantiate(deathEffect, transform.position, Quaternion.identity);	
		Destroy(gameObject);
	}
}
