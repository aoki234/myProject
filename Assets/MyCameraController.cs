using UnityEngine;
using System.Collections;

public class MyCameraController : MonoBehaviour {
	//harukoちゃんのオブジェクト
	private GameObject haruko;
	//harukoちゃんとカメラの距離
	private float difference;

	// Use this for initialization
	void Start () {
		//harukoちゃんのオブジェクトを取得
		this.haruko = GameObject.Find ("Haruko");
		//harukoちゃんとカメラの位置（z座標）の差を求める
		this.difference = haruko.transform.position.z - this.transform.position.z;

	}

	// Update is called once per frame
	void Update () {
		//Unityちゃんの位置に合わせてカメラの位置を移動
		this.transform.position = new Vector3(0, this.transform.position.y, this.haruko.transform.position.z-difference);
	}
}