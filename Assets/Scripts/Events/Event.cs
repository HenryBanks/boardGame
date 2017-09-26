using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Event : MonoBehaviour {

	Text titleText;
	Text descriptionText;
	Text option1Text;
	Text option2Text;

	List<Condition> option1Conditions;
	List<int> option1CondVals;
	List<Effect> option1EffectsTrue;
	List<int> option1VariablesTrue;
	List<Effect> option1EffectsFalse;
	List<int> option1VariablesFalse;

	List<Condition> option2Conditions;
	List<int> option2CondVals;
	List<Effect> option2EffectsTrue;
	List<int> option2VariablesTrue;
	List<Effect> option2EffectsFalse;
	List<int> option2VariablesFalse;

	public EventData testEventData;

	public static Event instance;

	void Awake(){
		instance = this;

		option1Conditions = new List<Condition> ();
		option1CondVals = new List<int> ();

		option1EffectsTrue=new List<Effect>();
		option1VariablesTrue=new List<int>();

		option1EffectsFalse=new List<Effect>();
		option1VariablesFalse=new List<int>();

		option2Conditions = new List<Condition> ();
		option2CondVals = new List<int> ();

		option2EffectsTrue=new List<Effect>();
		option2VariablesTrue=new List<int>();

		option2EffectsFalse=new List<Effect>();
		option2VariablesFalse=new List<int>();

		titleText = transform.Find ("EventTitle").GetComponent<Text> (); 
		descriptionText = transform.Find ("EventDescription").GetComponent<Text> ();
		option1Text = transform.Find ("EventOption1").GetComponent<Button> ().GetComponentInChildren<Text>();
		option2Text = transform.Find ("EventOption2").GetComponent<Button> ().GetComponentInChildren<Text>();

	}

	// Use this for initialization
	void Start () {

		loadEventData (testEventData);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void doOption1(){
		bool success = true;

		for (int ii = 0; ii < option1Conditions.Count; ii++) {
			if (!option1Conditions[ii].checkCondition(option1CondVals[ii])){
				success = false;
			}
		}

		if (success) {
			for (int ii = 0; ii < option1EffectsTrue.Count; ii++) {
				option1EffectsTrue [ii].doEffect (option1VariablesTrue [ii]);
			}
		} else {
			for (int ii = 0; ii < option1EffectsFalse.Count; ii++) {
				option1EffectsFalse [ii].doEffect (option1VariablesFalse [ii]);
			}
		}
		EventManager.instance.endEvent ();
	}

	public void doOption2(){
		bool success = true;

		for (int ii = 0; ii < option2Conditions.Count; ii++) {
			if (!option2Conditions[ii].checkCondition(option2CondVals[ii])){
				success = false;
			}
		}

		if (success) {
			for (int ii = 0; ii < option2EffectsTrue.Count; ii++) {
				option2EffectsTrue [ii].doEffect (option2VariablesTrue [ii]);
			}
		} else {
			for (int ii = 0; ii < option2EffectsFalse.Count; ii++) {
				option2EffectsFalse [ii].doEffect (option2VariablesFalse [ii]);
			}
		}
		EventManager.instance.endEvent ();
	}

	void loadEventData(EventData inputEvent){
		
		titleText.text = inputEvent.title;
		descriptionText.text = inputEvent.description;
		option1Text.text = inputEvent.option1Text;
		option2Text.text = inputEvent.option2Text;

		for (int ii = 0; ii<inputEvent.conditions1.Count; ii++) {
			option1Conditions.Add (GetInstance<Condition> (inputEvent.conditions1 [ii].name));
			option1CondVals.Add (inputEvent.conditions1 [ii].val);
		}

		for (int ii = 0; ii<inputEvent.effects1true.Count; ii++) {
			option1EffectsTrue.Add (GetInstance<Effect>(inputEvent.effects1true[ii].name));
			option1VariablesTrue.Add (inputEvent.effects1true[ii].val);
		}

		for (int ii = 0; ii<inputEvent.effects1false.Count; ii++) {
			option1EffectsFalse.Add (GetInstance<Effect>(inputEvent.effects1false[ii].name));
			option1VariablesFalse.Add (inputEvent.effects1false[ii].val);
		}

		for (int ii = 0; ii<inputEvent.conditions2.Count; ii++) {
			option2Conditions.Add (GetInstance<Condition>(inputEvent.conditions2[ii].name));
			option2CondVals.Add (inputEvent.conditions2[ii].val);
		}

		for (int ii = 0; ii<inputEvent.effects2true.Count; ii++) {
			option2EffectsTrue.Add (GetInstance<Effect>(inputEvent.effects2true[ii].name));
			option2VariablesTrue.Add (inputEvent.effects2true[ii].val);
		}

		for (int ii = 0; ii<inputEvent.effects2false.Count; ii++) {
			option2EffectsFalse.Add (GetInstance<Effect>(inputEvent.effects2false[ii].name));
			option2VariablesFalse.Add (inputEvent.effects2false[ii].val);
		}
	}

	public T GetInstance<T>(string typeName){

		return (T)Activator.CreateInstance (Type.GetType(typeName));
	}


}
