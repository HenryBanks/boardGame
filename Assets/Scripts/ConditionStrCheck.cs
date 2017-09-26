using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionStrCheck : Condition {

	public override bool checkCondition(int amount){
		Debug.Log ("Strength Check vs "+amount.ToString());

		int roll = PlayerStats.instance.getAttribute ((int)PlayerStats.Stats.Str).attributeTest ();

		Debug.Log (roll.ToString ());

		return (roll >= amount);
	}

}
