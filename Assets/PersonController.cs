using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonController : MonoBehaviour {

	private Rigidbody myRigidbody;
	//前進するための力（追加）
	private float turnForce;

	// Use this for initialization
	void Start () {
		this.myRigidbody = GetComponent<Rigidbody>();

		StartCoroutine ("move");  
	}
	
	//Update is called once per frame
	void Update () {
		Invoke ("move", 1.0f);
	}
	private IEnumerator move() {
		
		turnForce = Random.Range (-200, 200);

		this.myRigidbody.AddForce (this.turnForce, 0, 0);

		yield return new WaitForSeconds (1.0f); 
	}

	//void FixedUpdate(){
		
		//turnForce = Random.Range (-2, 2);
		//this.myRigidbody.AddForce (this.turnForce * 10 , 0, 0);
		//Debug.Log ("Done");
	//}

}
