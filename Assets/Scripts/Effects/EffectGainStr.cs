using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectGainStr : Effect {

	public override void doEffect(int amount){
		Debug.Log ("Add "+amount.ToString()+" to Strength");

		PlayerStats.instance.getAttribute ((int)PlayerStats.Stats.Str).addToValue (amount);
	}
}
