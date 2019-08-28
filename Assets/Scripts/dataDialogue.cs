using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dataDialogue : MonoBehaviour
{
	[Header ("Parameters")]
	[SerializeField] string name = "Put name here";
	[SerializeField] Vector3 offSet = Vector3.zero;

    void Start(){
        
    }
    
    void Update(){
        
    }

    public string GetName(){
    	return name;
    }

    public Vector3 GetPosition(){
    	return transform.position + offSet;
    }
}
