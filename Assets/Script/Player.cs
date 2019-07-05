using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
	Rigidbody2D rb;
	Animator anim;
	bool facingRight = true;
	float velX, speed = 2f;
	public float jumpValue;
	public static  int health = 10000;
	bool IsHurt, IsDead;
	public static float penanda;
	public GameObject heart;

	
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}


	void Update () {

		if(Input.GetKeyDown(KeyCode.RightShift))
		{
			penanda = 1;
			Debug.Log(penanda);
		}

		if (Input.GetKey (KeyCode.LeftShift))
			speed = 5f;
		else
			speed = 2f;
			
		AnimationState();

		if (!IsDead && health > 0){
			velX = Input.GetAxisRaw("Horizontal") * speed;

			if(Input.GetKeyDown (KeyCode.UpArrow)  && rb.velocity.y == 0)
				rb.AddForce (Vector2.up * jumpValue);

			if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.LeftArrow)){
				GetComponent<AudioSource> ().UnPause ();
			}
			else {
				GetComponent<AudioSource> ().Pause ();
			}
		}
	}
	

	void FixedUpdate()
	{
		if (!IsHurt)
			rb.velocity = new Vector2 (velX, rb.velocity.y);


		if (health < 0 || health == 0){
			Debug.Log("Mati");
			StartCoroutine ("gameOver");
			anim.SetTrigger("IsDead");
		}

	}

	void LateUpdate(){
		CheckWhereToFace();
	}

	void CheckWhereToFace(){
		Vector3 localScale = transform.localScale;
		if (velX > 0)
		{
			facingRight = true;
		}
		else if (velX < 0)
		{
			facingRight = false;
		}
		if (((facingRight) && (localScale.x < 0)) || (!facingRight) && (localScale.x > 0))
		{
			localScale.x *= -1;
		}

		transform.localScale = localScale;
	}

	void AnimationState()
	{
		if (velX == 0)
		{
			anim.SetBool("IsWalking", false);
			anim.SetBool("IsRunning", false);
		}
		if (rb.velocity.y == 0){
			anim.SetBool ("IsJumping", false);
			anim.SetBool ("IsFalling", false);
		}
		if (Mathf.Abs(velX) == 2 && rb.velocity.y == 0)
			anim.SetBool ("IsWalking", true);
		if (Mathf.Abs(velX) == 5 && rb.velocity.y == 0)
			anim.SetBool ("IsRunning", true);
		else
			anim.SetBool ("IsRunning", false);

		if(Input.GetKey (KeyCode.DownArrow) && Mathf.Abs(velX) == 5)
			anim.SetBool ("IsSliding", true);
		else
			anim.SetBool ("IsSliding",false);

		if (rb.velocity.y > 0){
			anim.SetBool ("IsJumping", true);
		}
		if (rb.velocity.y < 0){
			anim.SetBool ("IsJumping", false);
			anim.SetBool ("IsFalling", true);
		}			
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if(col.gameObject.name.Equals ("Cactus")){
			health -= 1;
			HealthScore.Nyawa -= 1;
		}
		if(col.gameObject.name.Equals ("Heart")){
			health = 100;
			HealthScore.Nyawa = 100;
			Destroy(heart);
		}
		if(col.gameObject.name.Equals ("MilosSkin")){
			health -= 1;
			HealthScore.Nyawa -= 1;
		}
		if(col.gameObject.name.Equals ("EsenseSkin")){
			health -= 1;
			HealthScore.Nyawa -= 1;
		}
		if(col.gameObject.name.Equals ("Stick")){
			health -= 1;
			HealthScore.Nyawa -= 1;
		}
		
		if(col.gameObject.name.Equals ("Spike")){
			health -= 1;
			HealthScore.Nyawa -= 1;
		}

		if(col.gameObject.name.Equals ("Water")  && health > 0){
			health = 0;
			HealthScore.Nyawa = 0;
			speed = 0;
			velX = 0;
			IsDead = true;
			anim.SetTrigger ("IsDead");
		}


		if(col.gameObject.name.Equals ("Cactus")  && health > 0){
			anim.SetTrigger ("IsHurt");
			StartCoroutine ("Hurt");	
		}

		if(col.gameObject.name.Equals ("MilosSkin")  && health > 0){
			anim.SetTrigger ("IsHurt");
			StartCoroutine ("Hurt");	
		}

		if(col.gameObject.name.Equals ("EsenseSkin")  && health > 0){
			anim.SetTrigger ("IsHurt");
			StartCoroutine ("Hurt");	
		}
		
		if(col.gameObject.name.Equals ("Spike")  && health > 0){
			anim.SetTrigger ("IsHurt");
			StartCoroutine ("Hurt");	
		}
		
		if(col.gameObject.name.Equals ("Portal")  && health > 0){
			SceneManager.LoadScene ("Stage2");	
		}
		if(col.gameObject.name.Equals ("Portal2")  && health > 0){
			SceneManager.LoadScene ("CreditScene");	
		}

	}

	IEnumerator Hurt()
	{
		IsHurt = true;
		rb.velocity = Vector2.zero;

		if (facingRight)
			rb.AddForce (new Vector2(-200f, 200f));
		else
			rb.AddForce (new Vector2(200f, 200f));

		yield return new WaitForSeconds (2f);

		IsHurt = false;
	}

	IEnumerator gameOver()
	{
		yield return new WaitForSeconds (2f);
		SceneManager.LoadScene("Menu");
	}
}
