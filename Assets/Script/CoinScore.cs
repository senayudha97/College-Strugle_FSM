using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinScore : MonoBehaviour {


	public static int hitungCoin;
	Text tampilCoin;
	// Use this for initialization
	void Start () {
		hitungCoin = 0;
		tampilCoin = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		tampilCoin.text = "Coin:"+hitungCoin.ToString();
	}
}
