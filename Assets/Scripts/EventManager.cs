using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

	CanvasGroup mEventPanel;
	public static EventManager instance;

	void Awake(){
		instance = this;
		mEventPanel = transform.Find ("EventPanel").GetComponent<CanvasGroup> ();
		mEventPanel.gameObject.SetActive (false);
	}

	public void playEvent(){
		mEventPanel.gameObject.SetActive (true);
	}

	public void endEvent(){
		mEventPanel.gameObject.SetActive (false);
		MovementUI.instance.switchButtons (true);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
