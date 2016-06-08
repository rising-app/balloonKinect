using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody))]

public class balloonScript : MonoBehaviour {

	public GameObject brokenBalloonPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter(Collision collisionInfo){
		//if (collisionInfo.gameObject.tag == "drops") {
			Instantiate (brokenBalloonPrefab, transform.position, brokenBalloonPrefab.transform.rotation);
			Destroy (gameObject);
			Debug.Log ("Destroyed balloon by Drops!!!!");
		//}
	}
}
