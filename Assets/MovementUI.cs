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
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void rollDice(){
		Debug.Log ("Rolling dice");
		dice1Val = Random.Range (1, 6);
		dice2Val = Random.Range (1, 6);
		setDiceDisplay ();
	}

	void setDiceDisplay(){
		dice1.GetComponentInChildren<Text> ().text = dice1Val.ToString ();
		dice2.GetComponentInChildren<Text> ().text = dice2Val.ToString ();
	}
}
