using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float speed = 20f;
	public Rigidbody2D rb;
	public int damage = 5;
	
	// Update is called once per frame
	void Update () {
		rb.velocity = transform.right * speed;
	}

	void OnTriggerEnter2D(Collider2D hitinfo)
	{
		// Debug.Log(hitinfo.name);
		Enemy enemy = hitinfo.GetComponent<Enemy>();
		
		if(enemy != null)
		{
			enemy.TakeDamage(damage);
		}
		Destroy(gameObject);
	}
}
