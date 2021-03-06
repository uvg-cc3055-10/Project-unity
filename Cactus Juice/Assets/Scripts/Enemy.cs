//Andrea Arguello 17801, Mafer Lopez 17160
//Enemy.cs
//23/05/2018
//Mecanicas del arbol grande del final
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float radio;
    public float velocidad;
    private float vida = 100;

    GameObject arbol;

    //necesitamos obtener al objeto del character para verificar si este se encuentra en el radio de vision
    GameObject perro;

    //asi mismo necesitamos su posicion inicial del character 
    Vector3 position;
    Animator anim;

    // Use this for initialization
    void Start()
    {
        arbol = GameObject.FindGameObjectWithTag("Arbol");
        perro = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        position = transform.position;



    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = position;


        float dist = Vector3.Distance(perro.transform.position, transform.position);
        if (dist < radio) target = perro.transform.position;

        anim.SetBool("moving", true);
        float fixedSpeed = velocidad * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);


    }

//tiene mayor vida pero igual muere con ataques de burbujas
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("bubbles(Clone)"))
        {
            if (vida >= 20)
            {
                vida -= 20;
            }
            else
            {
                DestroyObject(arbol);
            }

        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("bubbles(Clone)"))
        {
            if (vida >= 20)
            {
                vida -= 20;
            }
            else
            {
                DestroyObject(arbol);
            }

        }
    }

}
