//Andrea Arguello 17801, Mafer Lopez 17160
//AudioScript.cs
//23/05/2018
//Mantiene la musica sonando en todas las escenas
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour {

    static AudioSource audio;

	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();
        audio.Play();

    }
	
	// No destruye el audio aunque cambie de escena
	void Update () {
        DontDestroyOnLoad(audio);
		
	}

}
