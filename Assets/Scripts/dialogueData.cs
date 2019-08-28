/*Created by CaelumLaron*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Sentence{
	[SerializeField] public int index;
	[TextArea(3, 10)][SerializeField] public string sentence;
}

[CreateAssetMenu(menuName="Dialogue Log")]
public class dialogueData : ScriptableObject{
	[Header ("Dialogue")]
	[SerializeField] int characters;
	[SerializeField] Sentence[] sentences;

	public int[] GetOrder(){
		int sentencesTam = sentences.Length;
		int[] indexOf = new int[sentencesTam];
		for(int i=0; i<sentencesTam; ++i)
			indexOf[i] = sentences[i].index;
		return indexOf;
	}

	public string[] GetChat(){
		int sentencesTam = sentences.Length;
		string[] indexOf = new string[sentencesTam];
		for(int i=0; i<sentencesTam; ++i)
			indexOf[i] = sentences[i].sentence;
		return indexOf;
	}
}
