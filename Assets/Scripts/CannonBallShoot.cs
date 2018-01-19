using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallShoot : MonoBehaviour {
	[SerializeField]
	private GameObject projectile;
	[SerializeField]
	private float projectileForce = 500f;
	[SerializeField]
	GameObject spawn;

	Rigidbody2D _rb;
	Transform _transform;
	private Animator _animator = null;

	// Use this for initialization
	void Start () {
		_animator = gameObject.GetComponent<Animator> ();
		_transform = gameObject.transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.F)) {
			//Set the trigger to initiate the animation (check animator in the "fire" state)
			_animator.SetTrigger ("fire");
			//The cannonball can be shot from here, but there is a small delay
			//in between the animation and the actual shot. So, we will call this
			//method from the animator
			//FireCannonBall ();
		}
	}

	public void FireCannonBall(){
		GameObject p = 
			Instantiate (projectile,
				_transform.position, 
				Quaternion.identity);
		
		_rb = p.GetComponent<Rigidbody2D> ();

		//This is just so the cannon doesnt move back when it shoots
		Physics2D.IgnoreCollision (
			gameObject.GetComponent<Collider2D> (),
			p.GetComponent<Collider2D> ());
		
		_rb.AddForce (_transform.right
			* projectileForce
			*_transform.localScale.x);
		
		p.transform.localScale = _transform.localScale;
	}
}
