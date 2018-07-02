using UnityEngine;
using System.Collections;

public class PersonGenerator : MonoBehaviour {
	//carPrefabを入れる
	public GameObject personPrefab;
	//coinPrefabを入れる
	public GameObject coinPrefab;
	//cornPrefabを入れる
	//public GameObject conePrefab;
	//スタート地点
	private int startPos = -160;
	//ゴール地点
	private int goalPos = 120;
	//アイテムを出すx方向の範囲
	private float posRange = 6.4f;

	// Use this for initialization
	void Start () {
		//一定の距離ごとにアイテムを生成
		for (int i = startPos; i < goalPos; i+=10) {
			//どのアイテムを出すのかをランダムに設定
			int num = Random.Range (0, 10);
			if (num <= 1) {
				//コーンをx軸方向に一直線に生成
				for (float j = -1; j <= 1; j += 0.4f) {
					//GameObject cone = Instantiate (conePrefab) as GameObject;
					//cone.transform.position = new Vector3 (4 * j, cone.transform.position.y, i);
				}
			} else {

				//レーンごとにアイテムを生成
				for (int j = -1; j < 2; j++) {
					//アイテムの種類を決める
					int item = Random.Range (1, 11);
					//アイテムを置くZ座標のオフセットをランダムに設定
					int offsetz = Random.Range(-5, 6);

					int offsetx = Random.Range (-4, 4);

					//60%コイン配置:30%車配置:10%何もなし
					if (1 <= item && item <= 4) {
						//コインを生成
						GameObject coin = Instantiate (coinPrefab) as GameObject;
						coin.transform.position = new Vector3 (posRange * offsetx, coin.transform.position.y, i + offsetz);
					} else if (5 <= item && item <= 7) {
						//生成
						GameObject person = Instantiate (personPrefab) as GameObject;
						person.transform.position = new Vector3 (posRange * offsetx, person.transform.position.y, i + offsetz);
					}
				}
			}
		}
	}

	// Update is called once per frame
	void Update () {

	}
}