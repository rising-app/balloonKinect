using UnityEngine;
using System.Collections;

public class timerScript : MonoBehaviour {

	//経過時間
	private float timerCount = 10;
	//タイマー動作フラグ
	private bool timerStarted;

    //ふうせん
    public GameObject[] balloonObj;

	GameObject scoreObj;
	GameObject balObj;

    NumberImageRenderer numberImageRenderer = null;
	int number;
	// Use this for initialization
	void Start () {
		scoreObj = GameObject.Find ("score");
		balObj = GameObject.Find ("balloon");
		Debug.Log (balObj + "###########################################");
		timerStarted = true;
		numberImageRenderer = GetComponent<NumberImageRenderer>();
		//this.gameObject.SetActive(false);
	}

	// Update is called once per frame
	void Update () {
        this.gameObject.SetActive(true);
		if (timerStarted) {
			timerCount -= Time.deltaTime;
			if (timerCount <= 0) {
				timerCount = 6;
				timerStarted = false;
                //タイマーを非表示にする
                this.gameObject.SetActive(false);

				scoreObj.SetActive (true);
				balObj.SetActive (true);

                //風船表示を復活させる
				balloonScripts balSc = balObj.GetComponent<balloonScripts>();
				Debug.Log (balSc);
				balSc.restartGame ();
                //for(int i = 0;i<3; i++)
                //{
                    //GameObject instance = (GameObject)Instantiate(balloonObj[i]);
                //}
                
            }
		}
		numberImageRenderer.Render((int)timerCount);

	}

	public void Restart(){
		Debug.Log ("restart ############################################################");
		timerCount = 9;
		this.gameObject.SetActive (true);

	}
}