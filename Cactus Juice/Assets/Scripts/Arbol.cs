﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arbol : MonoBehaviour {
    public float radio;
    public float velocidad;
    private float vida = 50;

    GameObject arbol;

    //necesitamos obtener al objeto del character para verificar si este se encuentra en el radio de vision
    GameObject perro;

    //asi mismo necesitamos su posicion inicial del character 
    Vector3 position;

    // Use this for initialization
    void Start()
    {
        arbol = GameObject.FindGameObjectWithTag("Arbol");
        perro = GameObject.FindGameObjectWithTag("Player");

        position = transform.position;



    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = position;


        float dist = Vector3.Distance(perro.transform.position, transform.position);
        if (dist < radio) target = perro.transform.position;


        float fixedSpeed = velocidad * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);


    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("bubbles"))
        {
            if (vida>= 15)
            {
                vida -= 15;
            } else
            {
                DestroyObject(arbol);
            }
            
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("bubbles"))
        {
            if (vida >= 15)
            {
                vida -= 15;
            }
            else
            {
                DestroyObject(arbol);
            }

        }
    }
}
