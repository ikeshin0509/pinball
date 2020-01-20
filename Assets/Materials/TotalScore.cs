using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TotalScore : MonoBehaviour {

	public int CloudPoint = 10; //雲の点数
	public int LargeStarPoint = 15; //大きな星の点数
	public int SmallStarPoint = 20; //小さな雲の点数
	public int TS; 
	GameObject AS; 

	// Use this for initialization
	void Start () {

			//シーン中からオブジェクトを取得
 		this.AS = GameObject.Find("TotalScore"); 
	}

	// Update is called once per frame
	public void Update (){

	//トータルスコアを取得

		AS.GetComponent<Text> ().text = "Total Score" + TS;

	}
		 
	public void OnCollisionEnter (Collision other) { 
			
			if(other.gameObject.tag == "SmallStarTag"){
				//オブジェクトに応じてスコアを加算　
			TS += SmallStarPoint;
			}else if(other.gameObject.tag == "LargeStarTag"){
				//オブジェクトに応じてスコアを加算　
			TS += CloudPoint;
			}else if(other.gameObject.tag == "LargeCloudTag" || other.gameObject.tag == "SmallCloudTag"){
				//オブジェクトによってスコアを加算
			TS += LargeStarPoint;

		}
			}

}

