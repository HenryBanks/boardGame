using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

	public IntVector2 gridPosition;

	public List<Tile> neighbors;

	public int movementCost=1;

	public bool passable = true;

	void Awake(){
		
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

//	void OnMouseDown(){
//		//Debug.Log (this);
//		//popupPanel.instance.gameObject.SetActive(true);
//		//UIManager.instance.makeActionList();
//		//popupPanel.instance.targetTile = this;
//		//popupPanel.instance.currentPlayer = GameManager.instance.currentPlayer;
//
//		if ((GameManager.instance.currentPlayer!=null)&&(popupPanel.instance.getAwaitingMove())) {
//			if (passable) {
//				popupPanel.instance.resetAwait();
//				GameManager.instance.currentPlayer.moveTo (this);
//			}
//		}
//
//		/*
//		if (GameManager.instance.currentChar.GetComponent<Player> ()!=null) {
//			if (passable) {
//				GameManager.instance.currentChar.GetComponent<Player> ().moveTo (this);
//			}
//		}*/
//	}

	public void generateNeighbors(){
		neighbors=new List<Tile>();

		//up
		if (gridPosition.y > 0) {
			IntVector2 n = new IntVector2 (gridPosition.x, gridPosition.y - 1);
			neighbors.Add(GridManager.instance.tileGrid[n.x][n.y]);
		}
		//down
		if (gridPosition.y < GridManager.instance.gridSize -1) {
			IntVector2 n = new IntVector2 (gridPosition.x, gridPosition.y + 1);
			neighbors.Add(GridManager.instance.tileGrid[n.x][n.y]);
		}
		//left
		if (gridPosition.x > 0) {
			IntVector2 n = new IntVector2 (gridPosition.x-1, gridPosition.y);
			neighbors.Add(GridManager.instance.tileGrid[n.x][n.y]);
		}
		//right
		if (gridPosition.x < GridManager.instance.gridSize-1) {
			IntVector2 n = new IntVector2 (gridPosition.x+1, gridPosition.y);
			neighbors.Add(GridManager.instance.tileGrid[n.x][n.y]);
		}
	}
}
