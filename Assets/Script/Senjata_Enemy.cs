using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Senjata_Enemy : MonoBehaviour {
    public GameObject senjata, player;
    public Vector2 kiri = new Vector2(-50, -4);
    public Vector2 kanan = new Vector2(50, -4);
    float waktu = -0.7f, waktu1 = -2f, waktu_ikut  = -0.1f, jaraktembak, nilai1;
    // Use this for initialization

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<Rigidbody2D>().AddForce(kiri);
        nilai1 = transform.position.x;
        transform.position = new Vector2(transform.position.x, -4);
    }
    // Update is called once per frame

    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        waktu -= Time.deltaTime;
        waktu1 -= Time.deltaTime;
        waktu_ikut -= Time.deltaTime;
        jaraktembak = (player.transform.position.x + 5.8f);
        if (jaraktembak >= transform.position.x) //jarak tembak
        {
            if (waktu <= 0)
            {
                Instantiate(senjata, new  Vector2(transform.position.x, -4), Quaternion.identity); //senjata keluar
                waktu = 1f;
            }
            else if (waktu1 <= 0)//pindah posisi
            {
                transform.position = new
                Vector2(transform.position.x, -4);
                waktu1 = 2f;
            }
        }
        else
        {
            if (transform.position.x < nilai1)
            {
                GetComponent<Rigidbody2D>().AddForce(kanan);
            }
        }
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}