using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
	//Settings
	[Header ("Movement Settings")]
	[SerializeField] float speed = .2f;
    
	//Global Variables
	Rigidbody2D rg2d;

    void Start(){        
    	rg2d = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update(){
    	float xPos = Input.GetAxisRaw("Horizontal");
    }
}
