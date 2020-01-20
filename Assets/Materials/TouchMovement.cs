using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMovement : MonoBehaviour
{

	//HingeJointコンポーネントを入れる　
	private HingeJoint myHingeJoint; 

	//初期の傾き　
	private float defaultAngle = 20; 
	//弾いた時の傾き　
	private float flickAngle = -20; 

	// Use this for initialization
	void Start () 
	{
		//HIngeJointコンポーネント取得
		this.myHingeJoint = GetComponent<HingeJoint> (); 

		//フリッパーの傾きを設定　
		SetAngle(this.defaultAngle); 
	}


	// Update is called once per frame
	void Update () 
	{

		//タッチがされている場合
		if (0 < Input.touchCount) 
		{
			//タッチのカウンター関数を起動
			for (int i = 0; i < Input.touchCount; i++) 
			{
				//（i）番目のタッチを取得
				Touch t = Input.GetTouch (i);

				//タッチしたかどうか
				if (t.phase == TouchPhase.Began) 
				{ 
					//画面上のどこをタッチしたかによって左右フリッパーの動きを変える
					if (t.position.x >= 375 && tag == "RightFripperTag") {
						SetAngle (this.flickAngle);
						Debug.Log (t.position.x);
					} else if (t.position.x <= 375 && tag == "LeftFripperTag") {
						SetAngle (this.flickAngle);
					}
					Debug.Log (t.position.x);
				}
			
		
					
				//タッチされなくなった場合
					if (t.phase == TouchPhase.Ended) 
				{ 
						if (tag == "RightFripperTag") 
					{    
							SetAngle (this.defaultAngle);
							Debug.Log ("動いている");
					}
				else if (tag == "LeftFripperTag") 
					{	
					
						SetAngle (this.defaultAngle);
						Debug.Log ("動いている");
					} 

				}
			}
		}	
	}

		//フリッパーの傾きを設定
     public void SetAngle (float angle)
	{
		JointSpring jointSpr = this.myHingeJoint.spring;
		jointSpr.targetPosition = angle; 
					this.myHingeJoint.spring = jointSpr;
	}
}			


