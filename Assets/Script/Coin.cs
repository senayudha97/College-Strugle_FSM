using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class Coin : MonoBehaviour {

	public AudioSource AudioSrc;
	public AudioClip coin;
	void Start()
	{
		AudioSrc = GetComponent<AudioSource> ();
		coin = (AudioClip)AssetDatabase.LoadAssetAtPath("Asset/Ost/coin.wav", typeof(AudioClip));
	}

	void OnTriggerEnter2D (Collider2D col){

		if (col.gameObject.tag.Equals ("Player")){
			AudioSrc.clip = coin;
			AudioSrc.Play(0);
			Destroy (gameObject);
			CoinScore.hitungCoin += 50;
		}
	}
}
