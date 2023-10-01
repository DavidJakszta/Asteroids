using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
	ParticleSystem boost;
	public Material flashMaterial;
	public Material originalMaterial;
	Rigidbody2D rb;
	SpriteRenderer sr;
	ParticleSystem boost2;
	bool forceOn;
	bool forceBack;
	float forceAmount = 10.0f;
	float torqueDirection = 0.0f;
	float torqueAmount = 0.5f;
	public Bullet bullet;
	
	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		sr = GetComponent<SpriteRenderer>();
		// boost = GetComponent<ParticleSystem>();
		boost = GameObject.Find("Boost").GetComponent<ParticleSystem>();

		//sr.color = new Color(1f, 0f, 1f, 0.9f);
	}

	// Update is called once per frame
	void Update(){
		if(Input.GetKeyDown(KeyCode.Space)){
			Bullet theBullet = Instantiate(bullet, transform.position, Quaternion.identity) as Bullet;
			theBullet.shoot(transform.up);
		}

		
		forceBack = Input.GetKey(KeyCode.S);
		forceOn = Input.GetKey(KeyCode.W);
		
		if (Input.GetKeyDown(KeyCode.S)) {
			// transform.RotateAround(transform.position, new Vector3(0, 0, 1), 180f); // turn ship around
			// forceOn = Input.GetKey(KeyCode.W);
		}

		if (Input.GetKey(KeyCode.A)){
			torqueDirection = 3.5f;
		} else if (Input.GetKey(KeyCode.D)) {
			torqueDirection = -3.5f;
		}else {
			torqueDirection = 0;
		}
	   
		wrapAroundBoundary();
	}

	void wrapAroundBoundary() {
		float x = transform.position.x;
		float y = transform.position.y;

		if(x > 9.6f) { x = x - 19.2f;}
		if(x < -9.6f) { x = x + 19.2f;}
		if(y > 5.4f) { y = y - 10.8f;}
		if(y < -5.4f) { y = y + 10.8f;}

		transform.position = new Vector2(x,y);
	}
	
	void FixedUpdate() {
		//move rotate
		if(forceOn) {
			rb.AddForce(transform.up * forceAmount);
			boost.Play();
		}
		if(forceBack) {
			rb.AddForce(transform.up * -forceAmount);
		}
		
		if(torqueDirection != 0) {
			rb.AddTorque(torqueDirection * torqueAmount);
		}
	}

	  void OnCollisionEnter2D( Collision2D other){
		if(other.gameObject.tag == "Astroid"){
			FindObjectOfType<GameManager>().decreaseLifes(rb.transform.position);
			turnOffCollisions();
			StartCoroutine(Blinking());
			Invoke("TurnOnCollisions", 3f);
			}
	  }

	IEnumerator Blinking(){

		for(int i = 0; i < 3; i++){
			//turn spriteRenderer material into white and wait 0.5s
			sr.material = flashMaterial;
			sr.color = new Color(1f, 1f, 1f, 0.2f);
			yield return new WaitForSeconds(0.5f);
			//turn spriteRenderer material into normal and wait 0.5s
			sr.material = originalMaterial;
			sr.color = new Color(1f, 1f, 1f, 0.2f);
			yield return new WaitForSeconds(0.5f);
		
		}
	}

	  void turnOffCollisions() {
		gameObject.layer = LayerMask.NameToLayer("Ignore");
	  }

	  void TurnOnCollisions() {
		sr.color = new Color(1f, 1f, 1f, 1f);
		gameObject.layer = LayerMask.NameToLayer("Ship");
	  }
}
