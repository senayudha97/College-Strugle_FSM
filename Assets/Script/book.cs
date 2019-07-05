using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class book : MonoBehaviour {
	public static bool show;
	public GameObject wshow;

	void start()
	{
		wshow.SetActive(false);
		show = false;
	}

	

	void OnCollisionEnter2D (Collision2D col){

		if (col.gameObject.tag.Equals ("Player")){
			Destroy (gameObject);
			Debug.Log("True");
			show = true;
			wshow.SetActive(true);
		}
	}
}
