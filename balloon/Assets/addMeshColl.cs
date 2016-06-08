using UnityEngine;
using System.Collections;

public class addMeshColl : MonoBehaviour {

	public GameObject obj;

	// Use this for initialization
	void Start () {
		obj.AddComponent<MeshCollider> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
