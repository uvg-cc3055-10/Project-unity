using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoverPersonaje : MonoBehaviour {
    private float vel = 6.0f;
    private bool arriba = false;
    private bool derecha = false;
    private bool izquierda = false;
    private float jumpforce = 350f;
    public Scrollbar scVida;
    public float vida = 100;
    float SPUelapsed = 0;
    bool SPUactive = false;
    Rigidbody2D rb;
    Animator anim;
    GameObject spike;
    GameObject SpeedPowerup;
    SpriteRenderer sr;
    AudioSource wimp;
    public Camera cam;
    public string leveltoLoad;
    public GameObject feet;
    public LayerMask layerMask;
    public bool onAir;

    // Use this for initialization
    void Start () {
        wimp = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        spike = GameObject.FindGameObjectWithTag("Spike");
        SpeedPowerup = GameObject.FindGameObjectWithTag("SpeedPowerup");
        cam.transform.position = new Vector3(rb.transform.position.x, cam.transform.position.y, cam.transform.position.z);
        anim.SetFloat("Speed", Mathf.Abs(0));
    }
	
    

	// Update is called once per frame
	void Update () {
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
            anim.SetFloat("Speed", Mathf.Abs(1.0f));
        }
        if (izquierda)
        {
            this.transform.Translate(Vector3.left * Time.deltaTime * vel);
            cam.transform.position = new Vector3(rb.transform.position.x, cam.transform.position.y, cam.transform.position.z);
            anim.SetFloat("Speed", Mathf.Abs(1.0f));

        }

        if (SPUactive == true)
        {
            if (SPUelapsed >= 0f && SPUelapsed < 4.0f)
            {
                
                    vel = 20.0f;
                    SPUelapsed += Time.deltaTime;
                
            }
            else
            {
                vel = 6.0f;
                SPUactive = false;
            }
        }

            sr.flipX = izquierda;
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer.Equals("Grass"))
        {
            onAir = false;
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

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("SpeedPowerup"))
        {
            SPUelapsed = 0f;
            SPUactive = true;
            DestroyObject(GameObject.FindGameObjectWithTag("SpeedPowerUp"));

        }
        if (collision.tag.Equals("Basurero"))
        {
            SceneManager.LoadScene(leveltoLoad);
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
        anim.SetFloat("Speed", Mathf.Abs(0));
    }

}
