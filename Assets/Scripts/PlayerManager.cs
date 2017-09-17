using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	public IntVector2 gridPosition;

	public static PlayerManager instance;

	void Awake(){
		instance = this;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void moveToTile(Tile destination){
		gridPosition = destination.gridPosition;
		transform.position = new Vector2 (gridPosition.x, gridPosition.y);
	}
}
