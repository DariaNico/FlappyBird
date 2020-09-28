using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flapper : MonoBehaviour {
	public static Flapper instance; //A reference to our game controller script so we can access it statically.

	public float upForce; //Upward force of the "flap".
	private bool isDead = false; //Has the player collided with a wall?

	private Animator anim; //Reference to the Animator component.
	private Rigidbody2D rb2d; //Holds a reference to the Rigidbody2D component of the flapper.


	void Awake() {
		// Enforce the singleton pattern for GameController
		//If we don't currently have a game controller...
		if (instance == null)
			//...set this one to be it...
			instance = this;
		//...otherwise...
		else if (instance != this)
			//...destroy this one because it is a duplicate.
			Destroy(gameObject);
	}

	void Start() {
		//Get reference to the Animator component attached to this GameObject.
		anim = GetComponent<Animator>();
		//Get and store a reference to the Rigidbody2D attached to this GameObject.
		rb2d = GetComponent<Rigidbody2D>();
	}

	void Update() {
		//Don't allow control if the flapper has died.
		if (!isDead) {
			//Look for input to trigger a "flap".
			if (ShouldFlap()) {
				// DEBUG LOG
				print("Flap Flap! velocity: " + rb2d.velocity + ", upForce: " + upForce);

				//...tell the animator about it and then...
				anim.SetTrigger("Flap");
				//...zero out the flapper's current y velocity before...
				rb2d.velocity = Vector2.zero;
				//	new Vector2(rb2d.velocity.x, 0);
				//..giving the flapper some upward force.
				rb2d.AddForce(new Vector2(0, upForce));
			}
		}
	}

	void OnCollisionEnter2D(Collision2D intruder) {
		// Zero out the flapper's velocity
		rb2d.velocity = Vector2.zero;

		if (instance.tag == "Test") {
			// DEBUG LOG
			print("Test Collision");
		} else {
			// If the flapper collides with something set it to dead...
			isDead = true;
			//...tell the Animator about it...
			anim.SetTrigger("Die");
			//...and tell the game controller about it.
			GameController.instance.FlapperDied();
		}
	}

	// Flapping controls here
	public bool ShouldFlap() {
		return Input.GetButtonDown("Flap") || Input.GetMouseButtonDown(0);
	}
}