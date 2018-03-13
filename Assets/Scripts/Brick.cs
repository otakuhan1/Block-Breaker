using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	
	public AudioClip crack;
	public Sprite[] hitSprites;
	public static int breakableCount=0;
	public GameObject smoke;
	
	private bool isBreakable;
	private int timesHits;
	private LevelManager levelManager;
	
	// Use this for initialization
	void Start () {
		isBreakable=(this.tag == "Breakable");
		//keep track of breakable bricks
		if(isBreakable){
			breakableCount++;
		}	
		timesHits=0;
		levelManager=GameObject.FindObjectOfType<LevelManager>();
		Debug.Log("the number of breakable blocks are "+breakableCount);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter2D(Collision2D collider){
		AudioSource.PlayClipAtPoint(crack, transform.position,0.3f);
		if(isBreakable){
			HandleHits();
		}
		
		
	}
	
	void HandleHits(){
		
		timesHits++;
		int maxHits = hitSprites.Length+1;
		if(timesHits>=maxHits){
			breakableCount--;
			levelManager.BrickDestroyed();
			Destroy(gameObject);
			SmokePuff();
		}else{
			LoadSprites();
		}
	}
	
	void SmokePuff(){
		//instantiate smoke prefab
		smoke.particleSystem.startColor=this.GetComponent<SpriteRenderer>().color;
		Instantiate(smoke, this.transform.position,Quaternion.identity);
	}
	
	void LoadSprites(){
		int spriteIndex = timesHits-1;
		if(hitSprites[spriteIndex]){
			this.GetComponent<SpriteRenderer>().sprite=hitSprites[spriteIndex];
		}else{
			Debug.LogError("Missing Sprites");
		}
		
	}
	
	
	//TODO
	void SimulateWin(){
		levelManager.LoadNextLevel();
	}
}
