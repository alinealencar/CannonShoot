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

	// Use this for initialization
	void Start () {
		_transform = gameObject.transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.F))
			FireCannonBall ();
	}

	public void FireCannonBall(){
		GameObject p = 
			Instantiate (projectile,
				_transform.position, 
				Quaternion.identity);
		
		_rb = p.GetComponent<Rigidbody2D> ();

		Physics2D.IgnoreCollision (
			gameObject.GetComponent<Collider2D> (),
			p.GetComponent<Collider2D> ());
		
		_rb.AddForce (_transform.right
			* projectileForce
			*_transform.localScale.x);
		
		p.transform.localScale = _transform.localScale;
	}
}
