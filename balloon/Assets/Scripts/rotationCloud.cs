using UnityEngine;
using System.Collections;

public class rotationCloud : MonoBehaviour {

    public Vector3 angle;
	
	void Update () {
        transform.Rotate(angle * Time.deltaTime);
	}
}
