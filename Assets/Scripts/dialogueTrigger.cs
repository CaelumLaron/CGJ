/*Created by CaelumLaron*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogueTrigger : MonoBehaviour
{
	[Header ("Dialogue")]
	[SerializeField] dialogueManager manager;
	[SerializeField] dialogueData chat = null;
	[SerializeField] Transform[] chaters = null;
	[SerializeField] Vector3[] offSets = null;

	public void TriggerChat(){
		int[] order = chat.GetOrder();
		string[] log = chat.GetChat();
		manager.StartChat(order, log, chaters, offSets);
	}
}
