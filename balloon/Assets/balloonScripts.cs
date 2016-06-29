using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]

public class balloonScripts : MonoBehaviour {
	SpriteRenderer MainSpriteRenderer;
	private AudioSource mAudio;
	private Renderer mRenderer;
	private Collider2D mCollider2D;
	private int leftBalloon;
	public Sprite[] blueBalloon;
	public Sprite[] redBalloon;
	public Sprite[] yellowBalloon;
    //public Sprite[] mightyBalloon;

	GameObject scoreObj;
	GameObject balloonObj;

    int balloonColorFixed;

    bool mightyMode;

    private float mightyTimerCount;


    // Use this for initialization
    void Start () {
		mAudio = GetComponent<AudioSource> ();
		mRenderer = GetComponent<Renderer> ();
		mCollider2D = GetComponent<Collider2D>();
		MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
		leftBalloon = 3;
		scoreObj = GameObject.Find ("score");
		balloonObj = GameObject.Find ("balloon");

        balloonColorFixed = Random.Range(0, 3);
        Debug.Log("Balloon Color : " + balloonColorFixed);

        switch (balloonColorFixed)
        {
            case 0:
                MainSpriteRenderer.sprite = blueBalloon[3];
                break;
            case 1:
                MainSpriteRenderer.sprite = redBalloon[3];
                break;
            case 2:
                MainSpriteRenderer.sprite = yellowBalloon[3];
                break;
        }


    }


    void Update()
    {
        if (mightyMode)
        {
            mightyTimerCount -= Time.deltaTime;
            Debug.Log("Mighty Mode Left Time : " + mightyTimerCount);
            if (mightyTimerCount <= 0)
            {
                mightyMode = false;
                Debug.Log("Mighty Mode End");

                //バルーンの色を元に戻す
                switch (balloonColorFixed)
                {
                    case 0:
                        MainSpriteRenderer.sprite = blueBalloon[leftBalloon];
                        break;
                    case 1:
                        MainSpriteRenderer.sprite = redBalloon[leftBalloon];
                        break;
                    case 2:
                        MainSpriteRenderer.sprite = yellowBalloon[leftBalloon];
                        break;
                }
            }
        }
    }

	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "drops" && mightyMode ==false){
			if (leftBalloon == 1) {
				mRenderer.enabled = false;
				mCollider2D.enabled = false;
				mAudio.Play ();

				//balloonObj.SetActive (false);

				//Destroy (gameObject, mAudio.clip.length);
				//タイマー止める
				//score.gameOver();
				//scoreObj.SetActive(false); //scoreを非表示
                Debug.Log("Score : "+scoreObj);
                score scoreScript = scoreObj.GetComponent<score> ();
                Debug.Log(scoreObj.GetComponent<score>());
				scoreScript.gameOver ();

			} else {
				mAudio.Play ();
				leftBalloon = leftBalloon - 1;
                //MainSpriteRenderer.sprite = blueBalloon [leftBalloon];

                switch (balloonColorFixed)
                {
                    case 0:
                        MainSpriteRenderer.sprite = blueBalloon[leftBalloon];
                        break;
                    case 1:
                        MainSpriteRenderer.sprite = redBalloon[leftBalloon];
                        break;
                    case 2:
                        MainSpriteRenderer.sprite = yellowBalloon[leftBalloon];
                        break;
                }
            }

		}

	}

	public void restartGame(){

        balloonColorFixed = Random.Range(0, 3);
        Debug.Log("Balloon Color : " + balloonColorFixed);

        leftBalloon = 3;
		//balloonObj.SetActive (true);
        mRenderer.enabled = true;
        mCollider2D.enabled = true;
        switch (balloonColorFixed)
        {
            case 0:
                MainSpriteRenderer.sprite = blueBalloon[leftBalloon];
                break;
            case 1:
                MainSpriteRenderer.sprite = redBalloon[leftBalloon];
                break;
            case 2:
                MainSpriteRenderer.sprite = yellowBalloon[leftBalloon];
                break;
        }



        Debug.Log("restart game : Left Balloon 3 ##################################");


    }

    public void healingBalloon()
    {
        if(leftBalloon != 3)
        {
            leftBalloon = leftBalloon + 1;
        }

        switch (balloonColorFixed)
        {
            case 0:
                MainSpriteRenderer.sprite = blueBalloon[leftBalloon];
                break;
            case 1:
                MainSpriteRenderer.sprite = redBalloon[leftBalloon];
                break;
            case 2:
                MainSpriteRenderer.sprite = yellowBalloon[leftBalloon];
                break;
        }
    }


    
    public void mightyBalloon()
    {
        /*
        //あたり判定をなくす
        Collider2D mCollider2D = GetComponent<Collider2D>();
        mCollider2D.enabled = false;
        */

        //無敵にする
        mightyMode = true;
        //MainSpriteRenderer.sprite = mightyBalloon[leftBalloon];
        Debug.Log("Mighty Mode ON");
        mightyTimerCount = 20;
    }

}