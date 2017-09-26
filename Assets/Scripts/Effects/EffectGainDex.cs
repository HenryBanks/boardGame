using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectGainDex : Effect {

	public override void doEffect(int amount){
		Debug.Log ("Add "+amount.ToString()+" to Dexterity");

		PlayerStats.instance.getAttribute ((int)PlayerStats.Stats.Dex).addToValue (amount);
	}
}
