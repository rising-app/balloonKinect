using UnityEngine;
using System.Collections;

public class generatePrefab : MonoBehaviour {

	public GameObject obj;

	public float interval = 1f;

	public GameObject[] dropsObj;

    // 爆発のPrefab
    public Sprite explosion;
    //public GameObject explosion;
    public GameObject hissatsuPose;

    //経過時間
    private float timePassed = 0;
    //タイマー動作フラグ
    private bool hissatsutimerStarted;
    private bool hissatsu;

    // 爆発の作成
    public void Explosion()
    {
        Instantiate(explosion, transform.position, transform.rotation);
    }

    // Use this for initialization
    void Start () {
		StartCoroutine ("generateEnemy");
        hissatsuPose.SetActive(false);
        hissatsutimerStarted = true;
	}

    // Update is called once per frame
    void Update()
    {
        //ここは削除しないと。
        
        if (hissatsutimerStarted)
        {
            timePassed += Time.deltaTime;
            //Debug.Log(timePassed);
            if (timePassed >= 10)
            {
                timePassed = 10;
                Debug.Log("必殺技OK!!");
                hissatsutimerStarted = false;
                hissatsu = true;
                //必殺技ポーズを表示する
                hissatsuPose.SetActive(true);

            }
        }
        
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

    }

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
                //ochimono.Explosion();
                Destroy(ochimono);
                //爆発スプライト表示
                SpriteRenderer sr = ochimono.GetComponent<SpriteRenderer>();
                //ochimono.GetComponent<SpriteRenderer>() = explosion;
                sr.sprite = explosion;
            }

            //その後再カウント
            hissatsu = false;
            hissatsutimerStarted = true;
            hissatsuPose.SetActive(false);
            timePassed = 0;

            //healingBalloon
            GameObject balloonObj = GameObject.Find("balloon");
            balloonScripts bs = balloonObj.GetComponent<balloonScripts>();
            Debug.Log(bs);
            bs.healingBalloon();

            //mightyBalloon
            bs.mightyBalloon();

        }
    }

    IEnumerator generateEnemy(){
		//if (Input.GetMouseButtonDown (0)) {
		while(true){
			float x = Random.Range(-10f,10f); //0f
			float y = 8f;
			float z = -1f;

			//GameObject instance = (GameObject)Instantiate(obj, new Vector3(x,y,z),Quaternion.identity);

			int ochimonoNumber = Random.Range (0, 9);
			GameObject instance = (GameObject)Instantiate(dropsObj[ochimonoNumber], new Vector3(x,y,z),Quaternion.identity);
			//GameObject instance = (GameObject)Instantiate(dropsObj[ochimonoNumber], new Vector3(x,y,z),Quaternion.Euler(0,0,180));

			Destroy (instance, 4f);
			//instance.transform.position = gameObject.transform.position;
			//instance.transform.position = gameObject.transform.
			/*
			switch(Random.Range(0,3)){
			//case 0: instance.GetComponent<Renderer>().material.color = Color.red; break;
			case 0: GameObject instance = (GameObject)Instantiate(dropsObj[0], new Vector3(x,y,z),Quaternion.identity);
			case 1: instance.GetComponent<Renderer>().material.color = Color.blue; break;
			case 2: instance.GetComponent<Renderer>().material.color = Color.green; break;
			case 3: instance.GetComponent<Renderer>().material.color = Color.magenta; break;
			}
*/
			//}

			yield return new WaitForSeconds (interval);
		}

	}

} 