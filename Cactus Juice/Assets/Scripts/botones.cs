//Andrea Arguello 17801, Mafer Lopez 17160
//botones.cs
//23/05/2018
//Botones del display
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class botones : MonoBehaviour {

	public void PlayGame()
    {
        SceneManager.LoadScene("level1");
    }
}
