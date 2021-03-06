//Andrea Arguello 17801, Mafer Lopez 17160
//Spikes.cs
//23/05/2018
//Mecanicas de los spikes
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

    public float radio;
    public float velocidad;

    //necesitamos obtener al objeto del character para verificar si este se encuentra en el radio de vision
    GameObject perro;

    //asi mismo necesitamos su posicion inicial del character 
    Vector3 position;

	// Use this for initialization
	void Start () {

        perro = GameObject.FindGameObjectWithTag("Player");

        position = transform.position;



    }
	
	// Va persiguiendo al perrito 
	void Update () {
        Vector3 target = position;

   
        float dist = Vector3.Distance(perro.transform.position, transform.position);
        if (dist < radio) target = perro.transform.position;

    
        float fixedSpeed = velocidad * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);

      

    }
}
