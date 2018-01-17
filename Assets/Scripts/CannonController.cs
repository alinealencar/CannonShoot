using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour {
	[SerializeField]
	private float forceMultiplier = 100f;
	[SerializeField]
	private float upperBoundary = 27;
	[SerializeField]
	private float lowerBoundary = -60;

	private Rigidbody2D _rigidBody = null;

	private Vector2 _currentPos;

	// Use this for initialization
	void Start () {
		_rigidBody = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		_rigidBody.AddTorque (forceMultiplier * Input.GetAxis ("Vertical"));

		//Set the boundaries for the rotation
		if (_rigidBody.rotation > upperBoundary) {
			_rigidBody.rotation = upperBoundary;
			StopRotation();
		} else if (_rigidBody.rotation < lowerBoundary) {
			_rigidBody.rotation = lowerBoundary;
			StopRotation();
		}
					
	}

	private void StopRotation(){
		_rigidBody.angularVelocity = 0;
	}
}
