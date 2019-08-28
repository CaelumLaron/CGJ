/*Created by CaelumLaron*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
	//Settings
	[Header ("Movement Settings")]
	[SerializeField] float speed = .2f;

    //gameObject
    dialogueTrigger npcInte;
    bool stopMove = false;

    void Start(){
        npcInte = null;
    }

    void Update(){
        if(stopMove)
            return;
    	float xPos = Input.GetAxisRaw("Horizontal");
        transform.position += Vector3.right * xPos * speed;
        if(Input.GetAxis("Submit") == 1 && npcInte != null){
            npcInte.TriggerChat(this.gameObject);
            stopMove = true;
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        Debug.Log("NPC yes");
        npcInte = col.gameObject.GetComponent<dialogueTrigger>();
    }

    void OnTriggerExit2D(Collider2D col){
        Debug.Log("NPC not");
        npcInte = null;
    }

    public void FreeMove(){
        stopMove = false;
    }
}
