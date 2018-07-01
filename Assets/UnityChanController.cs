using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UnityChanController : MonoBehaviour {
	//アニメーションするためのコンポーネントを入れる
	private Animator myAnimator;
	//Unityちゃんを移動させるコンポーネントを入れる（追加）
	private Rigidbody myRigidbody;
	//前進するための力（追加）
	private float forwardForce = 1300.0f;

	private float turnForce = 500.0f;
	//左右の移動できる範囲（追加）
	private float movableRange = 20.5f;

	private float coefficient = 0.97f;

	private bool isEnd = false;

	private GameObject stateText;
	private GameObject scoreText;

	private int score = 0;

	private bool isLButtonDown = false;
	//右ボタン押下の判定
	private bool isRButtonDown = false;

	private bool isResetButtonDown = false;

	// Use this for initialization
	void Start () {

		//アニメータコンポーネントを取得
		this.myAnimator = GetComponent<Animator>();

		//走るアニメーションを開始
		this.myAnimator.SetFloat ("Speed", 1);

		//Rigidbodyコンポーネントを取得（追加）
		this.myRigidbody = GetComponent<Rigidbody>();

		this.stateText = GameObject.Find("GameResultText");

		this.scoreText = GameObject.Find("ScoreText");

	}

	// Update is called once per frame
	void Update () {

		//ゲーム終了ならUnityちゃんの動きを減衰する（追加）
		if (this.isEnd) {
			
			this.forwardForce *= this.coefficient;
			this.turnForce *= this.coefficient;
			this.myAnimator.speed *= this.coefficient;
		}


		//Unityちゃんに前方向の力を加える（追加）
		this.myRigidbody.AddForce (this.transform.forward * this.forwardForce);

		//Unityちゃんを矢印キーまたはボタンに応じて左右に移動させる（追加）
		if ((Input.GetKey (KeyCode.LeftArrow) || this.isLButtonDown) && -this.movableRange < this.transform.position.x) {
			//左に移動
			this.myRigidbody.AddForce (-this.turnForce, 0, 0);
		} else if ((Input.GetKey (KeyCode.RightArrow) || this.isRButtonDown) && this.transform.position.x < this.movableRange) {
			//右に移動
			this.myRigidbody.AddForce (this.turnForce, 0, 0);
		} 

		if (this.isResetButtonDown) {
			Application.LoadLevel("GameScene");
		}

		if (this.myAnimator.GetCurrentAnimatorStateInfo (0).IsName ("kick")) {
			this.myAnimator.SetBool ("kick",false);
		}

		//ジャンプしていない時にスペースが押されたらジャンプする（追加）
		if (Input.GetKeyDown (KeyCode.Space) && this.transform.position.z > 100) {
			//ジャンプアニメを再生（追加）
			this.myAnimator.SetBool ("kick", true);
		}
	}

	void OnTriggerEnter(Collider other) {

		//障害物に衝突した場合（追加）
		if (other.gameObject.tag == "PersonTag") {
			this.isEnd = true;

			this.stateText.GetComponent<Text>().text = "GAME OVER";
		}

		//ゴール地点に到達した場合（追加）
		if (other.gameObject.tag == "GoalTag") {
			this.isEnd = true;
			this.stateText.GetComponent<Text>().text = "GOALL!!";

			this.score += 20;

			//ScoreText獲得した点数を表示(追加)
			this.scoreText.GetComponent<Text> ().text = "Score " + this.score + "pt";

		}    

		if (other.gameObject.tag == "CoinTag") {
			this.score += 10;

			//ScoreText獲得した点数を表示(追加)
			this.scoreText.GetComponent<Text> ().text = "Score " + this.score + "pt";

			//接触したコインのオブジェクトを破棄
			Destroy (other.gameObject);
		}
	}


	public void GetMyLeftButtonDown() {
		this.isLButtonDown = true;
	}
	//左ボタンを離した場合の処理
	public void GetMyLeftButtonUp() {
		this.isLButtonDown = false;
	}

	//右ボタンを押し続けた場合の処理
	public void GetMyRightButtonDown() {
		this.isRButtonDown = true;
	}
	//右ボタンを離した場合の処理
	public void GetMyRightButtonUp() {
		this.isRButtonDown = false;
	}


	public void ResetButtonDown() {
		this.isResetButtonDown = true;
	}

	public void ResetButtonUp() {
		this.isResetButtonDown = false;
	}

}