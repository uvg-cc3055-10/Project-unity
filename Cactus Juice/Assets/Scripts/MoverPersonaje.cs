//Andrea Arguello 17801, Mafer Lopez 17160
//MoverPersonaje.cs
//23/05/2018
//Mecanicas del perrito
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoverPersonaje : MonoBehaviour {
    private float vel = 6.0f;
//variables para poder mover el personaje con los botones
    private bool arriba = false;
    private bool derecha = false;
    private bool izquierda = false;
    private float jumpforce = 350f;
    public Scrollbar scVida;
    static public float vida = 100;
    float SPUelapsed = 0;
    bool SPUactive = false;
//objets del mundo para poder controlarlos
    Rigidbody2D rb;
    Animator anim;
    GameObject spike;
    GameObject SpeedPowerup;
    SpriteRenderer sr;
    AudioSource wimp;
//audioclips para cada situacion descrita mas abajo en el codigo
    public AudioClip speedPu;
    public AudioClip wimper;
    public AudioClip vida1;
    public AudioClip tunel;
    public AudioClip boom;
    public Camera cam;
    public string leveltoLoad;
    public GameObject feet;
    public LayerMask layerMask;
    public bool onAir;

    private int nivel = 0; //para aumentar el daño que hace cada enemigo por nivel

  

    // se obtienen todos los objects del juego y componentes para poder crear los efectos y animaciones
    void Start () {
        wimp = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        spike = GameObject.FindGameObjectWithTag("Spike");
        SpeedPowerup = GameObject.FindGameObjectWithTag("SpeedPowerup");
        cam.transform.position = new Vector3(rb.transform.position.x, cam.transform.position.y, cam.transform.position.z);
        anim.SetFloat("Speed", Mathf.Abs(0));
        scVida.size = vida / 100f;
	    //Coloca la vida en 100 si se inicia el juego por primera vez o regresa a la primera escena
        if (SceneManager.GetActiveScene().name.Equals("level1"))
        {
            vida = 100;
            scVida.size = vida / 100f;
        }
    }
	
    

	/
	void Update () {
		//Salto
        if (arriba)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * jumpforce);
            anim.SetFloat("Speed", Mathf.Abs(0));
        }
		//movimiento a la derecha
        if (derecha)
        {
            this.transform.Translate(Vector3.right * Time.deltaTime * vel);
            cam.transform.position = new Vector3(rb.transform.position.x, cam.transform.position.y, cam.transform.position.z);
            anim.SetFloat("Speed", Mathf.Abs(1.0f));
        }
		//movimiento a la izquierda
        if (izquierda)
        {
            this.transform.Translate(Vector3.left * Time.deltaTime * vel);
            cam.transform.position = new Vector3(rb.transform.position.x, cam.transform.position.y, cam.transform.position.z);
            anim.SetFloat("Speed", Mathf.Abs(1.0f));

        }

		//Powerup de velocidad
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
	//Si se cae de una plataforma
        if (rb.transform.position.y < -10) SceneManager.LoadScene("GameOver");

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer.Equals("Grass"))
        {
            onAir = false;
        }
        
	    //si colisiona con cualquiera de estos objetos se le quita vida al perro, se declara el audioclip que sonora cuando esto passe
        if (collision.gameObject.name.Equals("Spike_Down") || collision.gameObject.name.Equals("Mace") || collision.gameObject.name.Equals("arbol"))
        {
            if (vida > 0)
            {
                
                    vida -= 10;
                    scVida.size = vida / 100f;
                    DestroyObject(spike);
                wimp.clip = wimper;

            } else 
            {
                SceneManager.LoadScene("GameOver");
            }

            wimp.Play();
        }
	    //condicion de ganador
        if (collision.gameObject.name.Equals("branch"))
        {
            SceneManager.LoadScene("Win");
        }
        
        
    }

	//Colliders de powerups, enemigos, entre otros
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("SpeedPowerup"))
        {
            SPUelapsed = 0f;
            SPUactive = true;
            wimp.clip = speedPu;
            DestroyObject(GameObject.FindGameObjectWithTag("SpeedPowerup"));
        }

        if (collision.tag.Equals("LifePowerup"))
        {
           
                vida += 10;
                scVida.size = vida / 100f;
                DestroyObject(GameObject.FindGameObjectWithTag("LifePowerup"));
            wimp.clip = vida1;
            
                
           
        }

        if (collision.tag.Equals("Spike"))
        {
            if (vida > 0)
            {
                wimp.clip = wimper;
                vida -= 15;
                scVida.size = vida / 100f;

            }
            else
            {
                SceneManager.LoadScene("GameOver");
            }
        }
	
	    //si colisiona con una bomba se le wuita vida, suena un clip y se destruye el objeto de la bomba
        if (collision.tag.Equals("Bomb"))
        {
            if (vida > 0)
            {
                wimp.clip = boom;
                vida -= 30;
                scVida.size = vida / 100f;
                DestroyObject(GameObject.FindGameObjectWithTag("Bomb"));

            } else
            {
                SceneManager.LoadScene("GameOver");
            }

        }
    
	    //si colisiona con unas espinas en el nivel 4 del juego se le resta vida
        if (collision.tag.Equals("espina"))
        {
            if (vida > 0)
            {
                vida -= 10;
                scVida.size = vida / 100f;
                wimp.clip = wimper;
            } else
            {
                SceneManager.LoadScene("GameOver");
            }
        }
        if (collision.tag.Equals("Basurero"))
        {
            SceneManager.LoadScene(leveltoLoad);
            wimp.clip = tunel;
            nivel += 1;
            
        }
	//Pone el sonido que se llame dependiendo de la colision
        wimp.Play();
    }

    public void MoverArriba()
    {
        arriba = true;
    }

	//Para los botones
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
