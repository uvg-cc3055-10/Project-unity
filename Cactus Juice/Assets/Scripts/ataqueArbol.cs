//Andrea Arguello 17801, Mafer Lopez 17160
//Arbol.cs
//23/05/2018
//ataqueArbol.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ataqueArbol : MonoBehaviour
{


    public float speed;

    GameObject player;
    Rigidbody2D rb2d;
    Vector3 target, dir;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb2d = GetComponent<Rigidbody2D>();

        // Se obtiene la posicion del jugador para que pueda ser almacenada y las balas de fuego lo sigan
        if (player != null)
        {
            target = player.transform.position;
            dir = (target - transform.position).normalized;
        }
    }

    void FixedUpdate()
    {

        if (target != Vector3.zero)
        {
            rb2d.MovePosition(transform.position + (dir * speed) * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // Si se choca contra el jugador o una de las burbujas de su ataque se destruye el objeto
        if (col.transform.tag == "Player" || col.gameObject.name.Equals("bubbles(Clone)"))
        {
            Destroy(gameObject);
           
        }
    }

    void OnBecameInvisible()
    {
        // se destruye el objeto si se sale de los limites de la pantalla
        Destroy(gameObject);
    }
}
