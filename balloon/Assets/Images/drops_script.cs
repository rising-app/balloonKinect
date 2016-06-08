using UnityEngine;
using System.Collections;

public class drops_script : MonoBehaviour {

	//private AudioSource mAudio;
	private Renderer mRenderer;
	private Collider2D mCollider2D;

	// Use this for initialization
	void Start () {
		//mAudio = GetComponent<AudioSource> ();
		mRenderer = GetComponent<Renderer> ();
		mCollider2D = GetComponent<Collider2D>();
	}

	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player"){
			mRenderer.enabled = false;
			mCollider2D.enabled = false;
			//mAudio.Play();
			//Destroy(gameObject,mAudio.clip.length);
		}
	}
}