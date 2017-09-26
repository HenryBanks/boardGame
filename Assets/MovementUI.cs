using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementUI : MonoBehaviour {

	Button rollButton;
	Button dice1;
	Button dice2;

	int dice1Val;
	int dice2Val;

	public static MovementUI instance;

	void Awake(){
		instance = this;
		rollButton = transform.Find ("Roll").GetComponent<Button> (); 
		dice1 = transform.Find ("Dice1").GetComponent<Button> ();
		dice2 = transform.Find ("Dice2").GetComponent<Button> ();
	}

	// Use this for initialization
	void Start () {
		switchButtons (true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void rollDice(){
		Debug.Log ("Rolling dice");
		dice1Val = Random.Range (1, 6);
		dice2Val = Random.Range (1, 6);
		setDiceDisplay ();
		switchButtons (false);
	}

	public void switchButtons(bool toRoll){
		rollButton.interactable = toRoll;
		dice1.interactable = !toRoll;
		dice2.interactable = !toRoll;
	}

	void disableAllButtons(){
		rollButton.interactable = false;
		dice1.interactable = false;
		dice2.interactable = false;
	}

	void setDiceDisplay(){
		dice1.GetComponentInChildren<Text> ().text = dice1Val.ToString ();
		dice2.GetComponentInChildren<Text> ().text = dice2Val.ToString ();
	}

	public void movePlayer(Button button){
		int diceVal;
		if (button == dice1) {
			diceVal = dice1Val;
		} else if (button == dice2) {
			diceVal = dice2Val;
		} else {
			Debug.Log ("ERROR");
			diceVal = 0;
			HUD.instance.Quit ();
		}

		int currentPos=PlayerManager.instance.positionOnRoad;

		int nextPos = (currentPos + diceVal) % GridManager.instance.roadList.Count;

		if (nextPos < 0)
			nextPos += GridManager.instance.roadList.Count;

		PlayerManager.instance.positionOnRoad = nextPos;

		Tile targetTile = GridManager.instance.roadList [nextPos];
		PlayerManager.instance.moveToTile (targetTile);

		//switchButtons (true);

		disableAllButtons ();

		EventManager.instance.playEvent ();

	}
}
