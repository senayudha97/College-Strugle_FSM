using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class peluru_musuh : MonoBehaviour {

	public float kecepataPeluru;
	private Transform player;
	private Vector2 target;
	public GameObject ledakan;
	
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").transform;

		target = new Vector2(player.position.x, player.position.y);
	}
	
	
	void Update () {
		
		transform.position = Vector2.MoveTowards(transform.position, target, kecepataPeluru * Time.deltaTime);

		if (transform.position.x == target.x && transform.position.y == target.y)
		{	
			HancurkanPeluru();
		}
	}

	void HancurkanPeluru(){
		Instantiate(ledakan, player.position, Quaternion.identity);	
		Destroy(gameObject);
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.name.Equals ("Player"))
		{
			Player.health -= 1;
			HealthScore.Nyawa -= 1;
		}
	}
}
