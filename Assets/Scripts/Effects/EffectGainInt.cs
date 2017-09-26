using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectGainInt : Effect {

	public override void doEffect(int amount){
		Debug.Log ("Add "+amount.ToString()+" to Intelligence");

		PlayerStats.instance.getAttribute ((int)PlayerStats.Stats.Int).addToValue (amount);
	}
}
