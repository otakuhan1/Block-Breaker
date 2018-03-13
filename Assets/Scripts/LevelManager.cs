using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name){
		Debug.Log ("New Level load: " + name);
		Application.LoadLevel (name);
		ResetBlockCount();
	}

	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}
	public void LoadNextLevel(){
		Application.LoadLevel(Application.loadedLevel+1);
		ResetBlockCount();
	}
	
	public void BrickDestroyed(){
		if(Brick.breakableCount<=0){
			LoadNextLevel();
		}
	}
	
	public static void ResetBlockCount(){
		Brick.breakableCount=0;
	}
}
