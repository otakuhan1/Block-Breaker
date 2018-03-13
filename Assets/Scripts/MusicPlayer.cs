using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer instance = null;
	
	void Awake(){
		//Debug.Log("Instance has been Awaken "+ GetInstanceID());
		if(instance!=null){
			Destroy(gameObject);
		}else{
			instance=this;		
			GameObject.DontDestroyOnLoad(gameObject); 	
		}
	}
	
	// Use this for initialization
	void Start () {
		//Debug.Log("Instance has been Started "+ GetInstanceID());
		
	}
	
	
	// Update is called once per frame
	void Update () {
	
	}
}
