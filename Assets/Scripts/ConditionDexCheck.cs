using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionDexCheck : Condition {

	public override bool checkCondition(int amount){
		Debug.Log ("Dexterity Check vs "+amount.ToString());

		int roll = PlayerStats.instance.getAttribute ((int)PlayerStats.Stats.Dex).attributeTest ();

		Debug.Log (roll.ToString ());

		return (roll >= amount);
	}

}
