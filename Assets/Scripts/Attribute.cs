using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attribute {

	string name;
	string description;
	int value;

	public Attribute(string inputName, string inputDescription, int inputValue){
		name = inputName;
		description = inputDescription;
		value = inputValue;
	}

	public int attributeTest(){
		int total = 0;
		for (int ii = 0; ii < value; ii++) {
			total += Random.Range (0, 2);
		}
		return total;
	}

}
