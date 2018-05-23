//Andrea Arguello 17801, Mafer Lopez 17160
//BubbleMove.cs
//23/05/2018
//Mecanicas del ataque del perrito, que son burbujas
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleMove : MonoBehaviour {
    public float speed = 3f;
    public float timer = 5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//Se mueve
        	transform.position += transform.right * speed * Time.deltaTime;
		//Se destruyen despues de un tiempo
        	Invoke("Destroy", timer);
		
	}

    public void Destroy()
    {
        transform.position = transform.parent.position;
        gameObject.SetActive(false);
    }
}
