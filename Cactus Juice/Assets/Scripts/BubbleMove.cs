//Andrea Arguello 17801, Mafer Lopez 17160
//BubbleMove.cs
//23/05/2018
//Mecanicas del ataque del perrito, que son burbujas
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleMove : MonoBehaviour {
	// se declaran las variables de la velocidad que tendra cada prefab de las burbujas y el tiempo por el cual esta permaneceran vivas
    public float speed = 3f;
    public float timer = 5f;

	// Use this for initialization
	void Start () {
		
	}
	
	
	void FixedUpdate () {
		//Se decalra el movimiento de las burbujas
        	transform.position += transform.right * speed * Time.deltaTime;
		//se llama al metodo de destruir las burbujas, estas son destruidas solo si ha pasado el tiempo que se declaro en las variables
        	Invoke("Destroy", timer);
		
	}

    public void Destroy()
    {
	    //si el tiempo ha pasado se comienzan a destruir las burbujas
        transform.position = transform.parent.position;
        gameObject.SetActive(false);
    }
}
