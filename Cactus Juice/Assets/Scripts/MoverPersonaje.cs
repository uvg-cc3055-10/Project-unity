using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoverPersonaje : MonoBehaviour {
    private float vel = 5.0f;
    private bool arriba = false;
    private bool derecha = false;
    private float jumpforce = 350f;
    public Scrollbar scVida;
    public float vida = 100;
    Rigidbody2D rb;
    Animator anim;
    GameObject spike;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spike = GameObject.FindGameObjectWithTag("Spike");

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

        anim.SetFloat("Speed", Mathf.Abs(move));
		
	}

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("basurero"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (collision.gameObject.name.Equals("Spike_Down"))
        {
            
            vida -= 10;
            scVida.size = vida / 100f;
            DestroyObject(spike);
        }
        if (collision.gameObject.name.Equals("Mace"))
        {
            vida -= 5;
            scVida.size = vida / 100f;
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
