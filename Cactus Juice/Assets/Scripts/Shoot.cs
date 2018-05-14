﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public Transform[] lanzadores;
    public float time = 0.4f;
    public bool fire = true;
    AudioSource efectos;
   public  AudioClip burbujas;

	// Use this for initialization
	void Start () {
        efectos = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown (KeyCode.Space) && fire)
        {
            foreach(Transform t in lanzadores)
            {
                MuniSpawner.spm(t.rotation, t.position);
                efectos.clip = burbujas;
                efectos.Play();

            }
            fire = false;
            Invoke("Reload", time);
            efectos.clip = burbujas;
            efectos.Play();
        }
		
	}

    public void Reload()
    {
        fire = true;
    }

    public void Disparar()
    {
        if (fire)
        {
            foreach (Transform t in lanzadores)
            {
                MuniSpawner.spm(t.rotation, t.position);
                efectos.clip = burbujas;
                efectos.Play();



            }
            fire = false;
            Invoke("Reload", time);
        }
        efectos.clip = burbujas;
        efectos.Play();
    }


}
