using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class dialogue{
	[Header ("Dialogue")]
	[SerializeField] string name = "Put character name here";
	[TextArea(3, 10)]
	[SerializeField] string[] sentences = null;

	public string GetName(){
		return name;
	}

	public string[] GetSentences(){
		return sentences;
	}
}
