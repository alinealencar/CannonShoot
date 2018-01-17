using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine ("Finish");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		Debug.Log ("collision");
		if (other.gameObject.tag.Equals ("rock")) {
			Debug.Log ("hit the rock");
			Destroy (gameObject);
			Destroy (other.gameObject);
			Player.Instance.Score += 100;
		}
	}

	private IEnumerator Finish(){
		yield return new WaitForSeconds (2);
		//Delete projectile after 2 seconds
		Destroy (gameObject);
	}
}
