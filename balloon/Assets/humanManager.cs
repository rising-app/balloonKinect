using UnityEngine;
using System.Collections;

public class humanManager : MonoBehaviour {
	//SpriteRenderer MainSpriteRenderer;
    int balloonCounter;

    // 爆発のPrefab
	//public Sprite explosion;
    public GameObject explosion;
	public GameObject hissatsuPose;

	//public GameObject hissatsuPose;

    // 爆発の作成
    public void Explosion()
    {
        Instantiate(explosion, transform.position, transform.rotation);
    }

    //経過時間
    private float timePassed = 0;
    //タイマー動作フラグ
    private bool hissatsutimerStarted;
    private bool hissatsu;

    // Use this for initialization
    void Start() {
        /*
		hissatsuPose = GameObject.FindGameObjectWithTag("gui");
		hissatsuPose.SetActive(false);
        hissatsutimerStarted = true;
        hissatsu = false;
        */
    }

    // Update is called once per frame
    void Update() {
        if (hissatsutimerStarted)
        {
            timePassed += Time.deltaTime;
            //Debug.Log(timePassed);
            if (timePassed >= 20)
            {
                timePassed = 20;
                Debug.Log("必殺技OK!!");
                hissatsutimerStarted = false;
                hissatsu = true;
                //必殺技ポーズを表示する
				hissatsuPose.SetActive(true);
                
            }
        }

        /*
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("QUIT");
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("必殺技発動");
            doHissatsu();
        }
        */

    }

    /*
    void doHissatsu()
    {
        if (hissatsu)
        {
            //KinectのColorBodySourceView.csで検出して、発動要請
            //必殺技発動。画面上のdropsをすべて消す。
            //Destroy(gameObject.tag(drops));
            GameObject[] ochimonos = GameObject.FindGameObjectsWithTag("drops");
            foreach (GameObject ochimono in ochimonos)
            {
                
                //爆発スプライト表示
				SpriteRenderer sr = ochimono.GetComponent<SpriteRenderer>();
				//ochimono.GetComponent<SpriteRenderer>() = explosion;
				sr.sprite = explosion;

                //ochimono.Explosion();
                Destroy(ochimono);
            }

            //その後再カウント
            hissatsu = false;
            hissatsutimerStarted = true;
        
        }
    }
    */

}