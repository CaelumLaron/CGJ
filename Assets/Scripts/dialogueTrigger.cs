using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueTrigger : MonoBehaviour
{
	//Dialogue
	[SerializeField] dialogue Dialogue = null;

	public void TriggerDialogue(){
		Object.FindObjectOfType<dialogueManager>().StartDialogue(Dialogue);
	}
}
