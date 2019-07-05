using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	
	public GameObject dBox;
	public Text dText;
	public bool dActive;

	void Start () {
		dActive = false;
		dBox.SetActive(false);
		
	}
	
	
	void Update () {
		if(dActive == true && Input.GetKeyDown(KeyCode.Tab))
		{
			dBox.SetActive(false);
			dActive = true;
			Destroy (gameObject);
		}
		
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if(col.gameObject.tag.Equals ("Player")  && dActive == false && Player.health > 0)
		{
			dBox.SetActive(true);
			dActive = true;
		}
		
		Debug.Log(dActive);
	}
}
