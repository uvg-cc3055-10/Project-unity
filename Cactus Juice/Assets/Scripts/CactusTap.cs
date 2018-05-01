using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusTap : MonoBehaviour {
    Animator anim;
    Touch touch;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {
        anim.SetBool("Speed", true);
        if (Input.touchCount > 0)
        {
            Debug.Log(Input.GetTouch(0).position);
        }
        
	}
}

