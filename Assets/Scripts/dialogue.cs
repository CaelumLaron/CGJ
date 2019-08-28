using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]

public class dialogue{
	[Header ("Dialogue parameters")]
	[SerializeField] string name = "Put character name here";

	public string GetName(){
		return name;
	}
}
