using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomba : MonoBehaviour {
    Animator anim;
    AudioSource boom;
    GameObject bomba;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        boom = GetComponent<AudioSource>();
        bomba = GameObject.FindGameObjectWithTag("Bomb");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Perro"))
        {
            anim.SetBool("exploto", true);
            boom.Play();

            DestroyObject(bomba);
        }
    }
}
