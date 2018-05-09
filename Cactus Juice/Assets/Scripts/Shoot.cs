using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public Transform[] lanzadores;
    public float time = 0.4f;
    public bool fire = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown (KeyCode.Space) && fire)
        {
            foreach(Transform t in lanzadores)
            {
                MuniSpawner.spm(t.rotation, t.position);

            }
            fire = false;
            Invoke("Reload", time);
        }
		
	}

    public void Reload()
    {
        fire = true;
    }


}
