using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {
	public bool autoPlay=false;
	private Ball ball;
	// Use this for initialization
	void Start () {
		ball=GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
		if(autoPlay){
			AutoPlay();
		}else{	
			MoveWithMouse();
		}
	}
	
	void MoveWithMouse(){
		Vector3 paddlePos = new Vector3(8.0f, this.transform.position.y, 0f);
		float xPositionInBlockUnits=Input.mousePosition.x/Screen.width*16;
		
		paddlePos.x = Mathf.Clamp(xPositionInBlockUnits,1.16f,14.81f);
		this.transform.position = paddlePos;
	}
	
	void AutoPlay(){
		Vector3 paddlePos = new Vector3(8.0f, this.transform.position.y, 0f);
		Vector3 ballPos = ball.transform.position;
		
		paddlePos.x = Mathf.Clamp(ballPos.x,1.16f,14.81f);
		this.transform.position = paddlePos;
	}
}
