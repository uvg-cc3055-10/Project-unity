using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoverPersonaje : MonoBehaviour {
    private float vel = 5.0f;
    private bool arriba = false;
    private bool derecha = false;
    private bool izquierda = false;
    private float jumpforce = 350f;
    public Scrollbar scVida;
    public float vida = 100;
    Rigidbody2D rb;
    Animator anim;
    GameObject spike;
    SpriteRenderer sr;
    public AudioSource wimp;
    public Camera cam;

    // Use this for initialization
    void Start () {
        wimp = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        spike = GameObject.FindGameObjectWithTag("Spike");
        cam.transform.position = new Vector3(rb.transform.position.x, cam.transform.position.y, cam.transform.position.z);
    }
	
    

	// Update is called once per frame
	void Update () {
        float move = Input.GetAxis("Horizontal");
        if (move != 0)
        {
            rb.transform.Translate(new Vector3(1, 0, 0) * move * vel * Time.deltaTime);
            cam.transform.position = new Vector3(rb.transform.position.x, cam.transform.position.y, cam.transform.position.z);
        }
        if (arriba)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * jumpforce);
            anim.SetFloat("Speed", Mathf.Abs(0));
        }
        if (derecha)
        {
            this.transform.Translate(Vector3.right * Time.deltaTime * vel);
            cam.transform.position = new Vector3(rb.transform.position.x, cam.transform.position.y, cam.transform.position.z);
                anim.SetFloat("Speed", Mathf.Abs(1));
        }
        if (izquierda)
        {
            this.transform.Translate(Vector3.left * Time.deltaTime * vel);
            cam.transform.position = new Vector3(rb.transform.position.x, cam.transform.position.y, cam.transform.position.z);
                anim.SetFloat("Speed", Mathf.Abs(1));
            
        }
        if(arriba==false && izquierda==false && derecha == false)
        {
            anim.SetFloat("Speed", Mathf.Abs(0));
        }

        anim.SetFloat("Speed", Mathf.Abs(move));
        sr.flipX = izquierda;
		
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
            wimp.Play();
        }
        if (collision.gameObject.name.Equals("Mace"))
        {
            vida -= 5;
            scVida.size = vida / 100f;
            wimp.Play();
        }
    }

    public void MoverArriba()
    {
        arriba = true;
    }

    public void MoverDerecha()
    {
        derecha = true;
        izquierda = false;
    }

    public void MoverIzquierda()
    {
        izquierda = true;
        derecha = false;
    }

    public void Detener()
    {
        arriba = false;
        derecha = false;
        izquierda = false;
    }
}
