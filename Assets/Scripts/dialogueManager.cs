using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogueManager : MonoBehaviour
{
	[Header ("Dialogue Box")]
	[SerializeField] Text nameText = null;
	[SerializeField] Text dialogueText = null;

	//Data structure
	Queue<string> sentences;
    
    void Start(){
    	sentences = new Queue<string>();    
    }

    public void StartDialogue(dialogue Dialogue){
    	nameText.text = Dialogue.GetName();
    	sentences.Clear();
    	string[] dSentences = Dialogue.GetSentences();
    	foreach(string sentence in dSentences)
    		sentences.Enqueue(sentence);
    	DisplayNextSentence();
    }

    public void DisplayNextSentence(){
    	if(sentences.Count == 0){
    		EndDialogue();
    		return;
    	}
    	string sentence = sentences.Dequeue();
    	StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence){
    	dialogueText.text = "";
    	foreach(char letter in sentence.ToCharArray()){
    		dialogueText.text += letter;
    		yield return null; 
    	}
    }

    private void EndDialogue(){
    	Debug.Log("End of conversation!");
    }
}
