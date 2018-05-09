using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vida : MonoBehaviour {
    public Scrollbar scVida;
    public float vida = 100;

    public void Damage(float value)
    {
        vida -= value;
        scVida.size = vida / 100f;

    }
}
