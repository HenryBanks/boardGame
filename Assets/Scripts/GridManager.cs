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
	public List<Tile> roadList;
	bool roadStarted;

	//Instance
	public static GridManager instance;

	[SerializeField]
	Camera mainCamera;

	//UI
	//UIManager uiMan;

	void Awake(){
		instance = this;
		//uiMan = GetComponentInChildren<UIManager> ();
	}

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

	}

	public void SetupGridAndRoad(){
		generateGrid ();
		generateRoadList ();
	}

	void generateGrid(){
		mainCamera.transform.position = new Vector3 ((gridSize-1)/2f,(gridSize-1)/2f,-10);

		tileGrid = new List<List<Tile>> ();
		for (int i = 0; i < gridSize; i++) {
			List<Tile> tileLine=new List<Tile>();
			for (int j = 0; j < gridSize; j++) {
				if (isRoadPart (i, j)) {
					Tile t = Instantiate (roadPrefab, new Vector3 (i, j, 0), transform.rotation);
					t.gridPosition = new IntVector2 (i, j);
					tileLine.Add (t);
					if (roadList.Count==0) {
						roadList.Add (t);
					}
				} else {
					Tile t = Instantiate (grassPrefab, new Vector3 (i, j, 0), transform.rotation);
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

	void generateRoadList(){
		Tile initialTile = roadList [0];
		for (int i = 0; i < initialTile.neighbors.Count; i++) {
			Tile t = initialTile.neighbors[i];
			if (t.passable) {
				roadList.Add (t);
				break;
			}
		}

		bool Finished=false;

		while (!Finished) {
			for (int i = 0; i < roadList[roadList.Count-1].neighbors.Count; i++) {
				Tile t = roadList[roadList.Count-1].neighbors[i];
				if (!roadList.Contains (t) && t.passable) {
					roadList.Add (t);
					break;
				}
				if (t == initialTile && roadList.Count>2) {
					Debug.Log ("Found end");
					Finished = true;
				}
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
