using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GridManager.instance.SetupGridAndRoad ();
		PlayerManager.instance.moveToTile (GridManager.instance.roadList [0]);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
