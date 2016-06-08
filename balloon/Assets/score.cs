using UnityEngine;
using System.Collections.Generic;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

using FirebaseCSharp;
using System.Collections;
using System;

public class score : MonoBehaviour {

	//経過時間
	private float timePassed = 0;
	//タイマー動作フラグ
	private bool timerStarted;
	GameObject refObj;
	GameObject scoreObj;

	NumberImageRenderer numberImageRenderer = null;
	int number;
	// Use this for initialization

	Firebase firebase;
	Firebase frb_child;


	void Start () {
		timerStarted = true;
		refObj = GameObject.Find ("timer");
		refObj.SetActive (false);
		scoreObj = GameObject.Find ("score");

		numberImageRenderer = GetComponent<NumberImageRenderer>();

		firebase = Firebase.CreateNew("incandescent-fire-5294.firebaseio.com");
		//frb_child = firebase.Child("key14").Child("key21");

	}

	// Update is called once per frame
	void Update () {
		// 浮動小数点
		if (timerStarted) {
			timePassed += Time.deltaTime;
			if (timePassed >= 999) {
				timePassed = 999;
				//timerStarted = false;
			}
		} else {
			timePassed = 0;
		}

		numberImageRenderer.Render((int)timePassed);

	}

	public void gameOver(){
		Debug.Log (timePassed + "Game Over######################################################");
		timerStarted = false;

		//キャプチャしてサーバーに送信処理追加

		Dictionary<string, object> dict1 = new Dictionary<string, object>();
		dict1.Add("key11", timePassed);
        StartCoroutine(Firebase.ToCoroutine(firebase.SetValue, dict1));
        //dict1.Add("key12", 0.123);
        //dict1.Add("key13", 1000);

        //this.enabled = true;
        //scoreObj.enabled = true;
        //refObj.SetActive (true);

        /*
		timerScript ts = refObj.GetComponent<timerScript> ();
		Debug.Log (ts);
		ts.Restart ();
		*/

        //GameObject again = GameObject.FindGameObjects("timer");
        //again.timeScript.Restart ();

        //

    }

	public void restart(){
		timerStarted = true;
		timePassed = 0;
	}
}