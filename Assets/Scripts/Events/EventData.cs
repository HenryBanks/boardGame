using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName="Event/Event")]
public class EventData : UpdatableData {


	public string title;
	public string description;

	public string option1Text;

	public List<NameVal> conditions1;
	public List<NameVal> effects1true;
	public List<NameVal> effects1false;

	public string option2Text;

	public List<NameVal> conditions2;
	public List<NameVal> effects2true;
	public List<NameVal> effects2false;


	protected override void OnValidate()
	{
		base.OnValidate();


	}
}
