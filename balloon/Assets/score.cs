using UnityEngine;
using System.Collections.Generic;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

using FirebaseCSharp;
using System.Collections;
using System.IO;
//using UnityEditor;
using System;
using UnityEngine.UI;

public class score : MonoBehaviour {

	//経過時間
	private float timePassed = 0;
	//タイマー動作フラグ
	private bool timerStarted;
	GameObject refObj;
	GameObject scoreObj;
    GameObject humanObj;

	NumberImageRenderer numberImageRenderer = null;
	int number;
	// Use this for initialization

	Firebase firebase;
    //Firebase frb_child;
    private static readonly DateTime UNIX_EPOCH = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    private string datetimeStr;
    private long unixTime;
    private string utcTime;



	void Start () {
		timerStarted = true;
		refObj = GameObject.Find ("timer");
		refObj.SetActive (false);
		scoreObj = GameObject.Find ("score");
        humanObj = GameObject.Find("humanManager");

        //float xa = humanObj.transform.position.x;
        //float ya = humanObj.transform.position.z;
        //Debug.Log("human postion : " + xa + ", " + ya);

        numberImageRenderer = GetComponent<NumberImageRenderer>();

		firebase = Firebase.CreateNew("incandescent-fire-5294.firebaseio.com");

	}


	void Update () {
		// 浮動小数点
		if (timerStarted) {
			timePassed += Time.deltaTime;
			if (timePassed >= 999) {
				timePassed = 999;
				//timerStarted = false;
			}
		} else {
			//timePassed = 0;
		}
        /*
        Debug.Log("position :( " + this.transform.position.x + ", " + this.transform.position.y + " )");
        
        Vector2 capturePoint = RectTransformUtility.WorldToScreenPoint(Camera.main, this.transform.position);
        Debug.Log("Capture Point : (" + capturePoint + ")");
        */

        numberImageRenderer.Render((int)timePassed);

	}

	public void gameOver(){
		//Debug.Log (timePassed + "Game Over######################################################");
		timerStarted = false;
        Debug.Log(timePassed + "Game Over######################################################");

        Debug.Log(Application.dataPath);
        //string file = new FileInfo.Open (Application.dataPath + "/" + fileName, FileMode.Create);
        string file = Application.dataPath + "/captureImages/test.png";
        Debug.Log(file);


        Vector2 capturePoint = RectTransformUtility.WorldToScreenPoint(Camera.main, this.transform.position);
        Debug.Log("Capture Point : (" + capturePoint + ")");
        double x = capturePoint.x; // 300;//250;
        double y = capturePoint.y;// 230;//-150;



        //キャプチャしてサーバーに送信処理追加

        StartCoroutine(SaveTextureToFile((int)x, (int)y));

        Debug.Log(timePassed + "Game Over######################################################");

        //scoreObj.SetActive(false);




        //以下がFirebase部
        //Dictionary<string, object> dict1 = new Dictionary<string, object>();
        //dict1.Add("key11", timePassed);
        //StartCoroutine(Firebase.ToCoroutine(firebase.SetValue, dict1));
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

    private IEnumerator SaveTextureToFile(int x, int y)
    {
        Debug.Log("SaveTextureToFile IEnumerator, position ( " + x + ", " + y + " )");
        yield return new WaitForEndOfFrame();

        unixTime = (long)(System.DateTime.UtcNow - UNIX_EPOCH).TotalSeconds;
        Debug.Log(unixTime);

        //x,y座標を取得する

        numberImageRenderer.Render((int)timePassed);

        Debug.Log("human postion : " + x + ", " + y);

        int width = 200;
        int height = 200;

#if UNITY_EDITOR
        string fileName = Application.dataPath + "/captureImages/" + unixTime + ".png";
        Debug.Log("Unity Editor");
        
        int adjustx = 30;
        int adjusty = -50;

#elif UNITY_STANDALONE_WIN
        string fileName = "C:/data/capturedImages/" + unixTime + ".png";
        //string fileName = Application.dataPath + "/../../capturedImages/" + unixTime + ".png";
        Debug.Log("Unity StandAlone Win");
        width = 300;
        height = 300;
        int adjustx = 90;//50
        int adjusty = -120;
#endif

        //x,yはcapture開始位置
        x = x - width / 2 - adjustx;
        y = y - height / 2 - adjusty;

        if (x < 0)
        {
            x = 0;
        } else if (x + width > Screen.width)
        {
            x = Screen.width - width;
        }
        
        if (y < 0)
        {
            y = 0;
        }
        else if (y > Screen.height-height)
        {
            y = Screen.height - height;
        }
        
        Debug.Log("capture postion : " + x + ", " + y);

        Texture2D tex = new Texture2D(width, height, TextureFormat.RGB24, false);
        tex.ReadPixels(new Rect(x, y, width, height), 0, 0);
        tex.Apply();


        byte[] pngData = tex.EncodeToPNG();
        File.WriteAllBytes(fileName, pngData);
        //incandescent-fire-5294.firebaseio.com
        //firebase = Firebase.CreateNew("incandescent-fire-5294.firebaseio.com");
        firebase = Firebase.CreateNew("balloon-7766d.firebaseio.com");
        Dictionary<string, object> dict1 = new Dictionary<string, object>();
        Dictionary<string, object> dict2 = new Dictionary<string, object>();

        //int score = 100;
        //gs://balloon-7766d.appspot.com/test.png
        //string pngFilePath = "gs://incandescent-fire-5294.appspot.com/";
        string pngFilePath = "gs://balloon-7766d.appspot.com/";
        string pngFileName = unixTime + ".png";
        Debug.Log(pngFilePath + pngFileName + ", timePassed Score : " + timePassed);
        dict2.Add("imagePath", pngFilePath + pngFileName);
        dict2.Add("Score", timePassed);
        dict2.Add("saveTime", System.DateTime.Now);

        dict1.Add(unixTime.ToString(), dict2);

        StartCoroutine(Firebase.ToCoroutine(firebase.SetValue, dict1));

        timerScript ts = refObj.GetComponent<timerScript>();
        Debug.Log(ts);
        ts.Restart();

        //scoreObj.SetActive(false);
    }


    public void restartGame(){
		timerStarted = true;
		timePassed = 0;
	}
}