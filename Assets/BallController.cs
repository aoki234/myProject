using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

	//Harukoちゃんのオブジェクト
	private GameObject haruko;
	//Harukoちゃんとカメラの距離
	private float difference_z;

	private float difference_x;

	// Use this for initialization
	void Start () {
		//Harukoちゃんのオブジェクトを取得
		this.haruko = GameObject.Find ("Haruko");
		//Harukoちゃんとカメラの位置（z座標）の差を求める
		this.difference_z = haruko.transform.position.z - this.transform.position.z;

		this.difference_x = haruko.transform.position.x - this.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3(this.haruko.transform.position.x-difference_x, this.transform.position.y, this.haruko.transform.position.z-difference_z);

	}
}
