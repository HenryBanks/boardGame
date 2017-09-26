using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectMove : Effect {

	public override void doEffect(int amount){
		Debug.Log ("Moving forward");

		int currentPos=PlayerManager.instance.positionOnRoad;

		int nextPos = (currentPos + amount) % GridManager.instance.roadList.Count;

		if (nextPos < 0)
			nextPos += GridManager.instance.roadList.Count;

		PlayerManager.instance.positionOnRoad = nextPos;

		Tile targetTile = GridManager.instance.roadList [nextPos];
		PlayerManager.instance.moveToTile (targetTile);
	}
}
