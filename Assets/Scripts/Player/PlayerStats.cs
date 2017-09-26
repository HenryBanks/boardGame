using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

	public static PlayerStats instance;

	public enum Stats{Str,Dex,Int};

	public List<Attribute> attributesList;

	void Awake(){
		instance = this;

		attributesList = new List<Attribute> ();

		Attribute strength = new Attribute ("Strength", "How physically strong you are", 3);
		attributesList.Add (strength);

		Attribute dexterity = new Attribute ("Dexterity", "How nimble you are", 3);
		attributesList.Add (dexterity);

		Attribute intelligence = new Attribute ("Intelligence", "How smart you are", 3);
		attributesList.Add (intelligence);
	}

	public Attribute getAttribute(int attIt){
		return attributesList [attIt];
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
