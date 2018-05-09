using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleMove : MonoBehaviour {
    public float speed = 3f;
    public float timer = 5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position += transform.right * speed * Time.deltaTime;
        Invoke("Destroy", timer);
		
	}

    public void Destroy()
    {
        transform.position = transform.parent.position;
        gameObject.SetActive(false);
    }
}
