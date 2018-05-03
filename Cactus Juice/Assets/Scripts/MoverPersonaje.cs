using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoverPersonaje : MonoBehaviour {
    private float vel = 5.0f;
    private bool arriba = false;
    private bool derecha = false;
    private float jumpforce = 350f;
    Rigidbody2D rb;
    Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
		
	}
	
	// Update is called once per frame
	void Update () {
        float move = Input.GetAxis("Horizontal");
        if (arriba)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * jumpforce);
        }
        if (derecha)
        {
            this.transform.Translate(Vector3.right * Time.deltaTime * vel);
        }

        anim.SetFloat("vel", Mathf.Abs(move));
		
	}

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("basurero"))
        {
            SceneManager.LoadScene("Demo");
        }
    }

    public void MoverArriba()
    {
        arriba = true;
    }

    public void MoverDerecha()
    {
        derecha = true;
    }
      
    public void Detener()
    {
        arriba = false;
        derecha = false;
    }
}
