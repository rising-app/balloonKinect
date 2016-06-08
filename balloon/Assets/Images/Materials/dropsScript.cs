using UnityEngine;
using System.Collections;

public class dropsScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collisionInfo){
		Destroy (gameObject);
		Debug.Log ("Drops hit to Balloon!!");
	}
}
