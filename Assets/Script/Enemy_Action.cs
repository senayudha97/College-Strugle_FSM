using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Action : MonoBehaviour {

	public float jalan;
	public float mengejar;
	public float distance;
	private bool movingRight = true;
	public Transform groundDetection;
	public float jarakMengejar;
	public static int putar;
	public Transform player;
	public float waktuTembak;
	public float delayTembak;
	public GameObject peluru;

	void start()
	{
		

		delayTembak = waktuTembak;

	}


	void Update () {
		
		// enemy mengikuti player
		if (Vector2.Distance(transform.position, player.position) < jarakMengejar)
		{
			transform.position = Vector2.MoveTowards(transform.position, player.position, mengejar * Time.deltaTime);
			//delay tembak
			if (delayTembak <= 0)
			{
				Instantiate(peluru, transform.position, Quaternion.identity);
				delayTembak = waktuTembak;
			}
			else
			{
				delayTembak -= Time.deltaTime;
			}
		}
		//enemy patrol
		else if (Vector2.Distance(transform.position, player.position) > jarakMengejar)
		{
			transform.Translate(Vector2.right * jalan * Time.deltaTime);
			RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position,Vector2.down,distance);
			
			if(groundInfo.collider == false){ 
				if(movingRight == true){
					transform.eulerAngles = new Vector3(0, -180, 0);
					movingRight = false;
				} 
				else {
					transform.eulerAngles = new Vector3(0, 0, 0);
					movingRight = true;
				}
			}
		}
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if(col.gameObject.name.Equals ("Player")){
			// Debug.Log(Vector2.Distance(transform.position, player.position));
			putar += 1;
			if (putar % 2 == 0)
			{
				transform.eulerAngles = new Vector3(0, 0, 0);
			}
			else
			{
				transform.eulerAngles = new Vector3(0, -180, 0);
			}
		}
		
	}
}
