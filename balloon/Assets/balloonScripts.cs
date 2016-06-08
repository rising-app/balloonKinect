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
	GameObject refObj;
	GameObject balloonObj;

	// Use this for initialization
	void Start () {
		mAudio = GetComponent<AudioSource> ();
		mRenderer = GetComponent<Renderer> ();
		mCollider2D = GetComponent<Collider2D>();
		MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
		leftBalloon = 3;
		refObj = GameObject.Find ("score");
		balloonObj = GameObject.Find ("balloon");
	}

	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "drops"){
			if (leftBalloon == 1) {
				mRenderer.enabled = false;
				mCollider2D.enabled = false;
				mAudio.Play ();

				balloonObj.SetActive (false);

				//Destroy (gameObject, mAudio.clip.length);
				//タイマー止める
				//score.gameOver();
				refObj.SetActive(false);
				score scoreScript = refObj.GetComponent<score> ();
				scoreScript.gameOver ();

			} else {
				mAudio.Play ();
				leftBalloon = leftBalloon - 1;
				MainSpriteRenderer.sprite = blueBalloon [leftBalloon];
			}

		}

	}

	public void restartGame(){
		Debug.Log ("restart game ##################################");
		leftBalloon = 3;
		balloonObj.SetActive (true);
		MainSpriteRenderer.sprite = blueBalloon [leftBalloon];


	}

}