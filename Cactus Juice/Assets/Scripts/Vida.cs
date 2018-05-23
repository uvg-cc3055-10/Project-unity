//Andrea Arguello 17801, Mafer Lopez 17160
//Vida.cs
//23/05/2018
//Mecanicas de la barra de vida
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vida : MonoBehaviour {
    public Scrollbar scVida;
    public float vida = 100;

    //Si recibe daño, le resta a la vida y lo muestra en la barrita
    public void Damage(float value)
    {
        vida -= value;
        scVida.size = vida / 100f;

    }
}
