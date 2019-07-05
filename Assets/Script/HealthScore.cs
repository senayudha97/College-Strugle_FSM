using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScore : MonoBehaviour {

	public static int Nyawa;
	Text tampilHealth;
	void Start () {
		Nyawa = Player.health;
		tampilHealth = GetComponent<Text> ();
	}
	
	void Update () {
		tampilHealth.text = "Health:"+Nyawa.ToString();
	}
}
