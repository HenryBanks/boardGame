using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionIntCheck : Condition {

	public override bool checkCondition(int amount){
		Debug.Log ("Intelligence Check vs "+amount.ToString());

		int roll = PlayerStats.instance.getAttribute ((int)PlayerStats.Stats.Int).attributeTest ();

		Debug.Log (roll.ToString ());

		return (roll >= amount);
	}

}
