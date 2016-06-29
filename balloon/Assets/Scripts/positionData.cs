using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System;
using UnityEngine.UI;

public class positionData : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        Vector2 capturePoint = RectTransformUtility.WorldToScreenPoint(Camera.main, this.transform.position);

        Debug.Log("PositionData : (" + capturePoint + ")");
        double x = capturePoint.x; // 300;//250;
        double y = capturePoint.y;// 230;//-150;
    }
}
