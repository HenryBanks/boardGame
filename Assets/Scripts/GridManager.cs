using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour {

	//tilePrefab
	[SerializeField]
	Tile roadPrefab;

	[SerializeField]
	Tile grassPrefab;

	//grid info
	public List<List<Tile>> tileGrid;
	public int gridSize=10;
	float tileSize=1.0f;

	//Instance
	public static GridManager instance;

	//UI
	//UIManager uiMan;

	void Awake(){
		instance = this;
		//uiMan = GetComponentInChildren<UIManager> ();
	}

	// Use this for initialization
	void Start () {
		generateGrid ();
	}

	bool generateAImove=true;

	// Update is called once per frame
	void Update () {

	}

	void generateGrid(){
		tileGrid = new List<List<Tile>> ();
		for (int i = 0; i < gridSize; i++) {
			List<Tile> tileLine=new List<Tile>();
			for (int j = 0; j < gridSize; j++) {
				if (isRoadPart (i, j)) {
					Tile t = Instantiate (roadPrefab, new Vector3 (i * tileSize - gridSize / 2, j * tileSize - gridSize / 2, 0), transform.rotation);
					t.gridPosition = new IntVector2 (i, j);
					tileLine.Add (t);
				} else {
					Tile t = Instantiate (grassPrefab, new Vector3 (i * tileSize - gridSize / 2, j * tileSize - gridSize / 2, 0), transform.rotation);
					t.gridPosition = new IntVector2 (i, j);
					tileLine.Add (t);
				}
			}
			tileGrid.Add (tileLine);
		}
		for (int i = 0; i < gridSize; i++) {
			for (int j = 0; j < gridSize; j++) {
				tileGrid [i] [j].generateNeighbors ();
			}
		}
	}

	bool isRoadPart(int ii, int jj){
		if (ii == gridSize - 2 || jj == gridSize - 2 || ii == 1 || jj == 1) {
			if (ii != gridSize - 1 && jj != gridSize - 1 && ii != 0 && jj != 0)
				return true;
		}
		return false;
	}

	void exit(){
		if (UnityEditor.EditorApplication.isPlaying) {
			UnityEditor.EditorApplication.isPlaying = false;
		} else {
			Application.Quit ();
		}
	}


}
