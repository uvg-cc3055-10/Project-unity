using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuniSpawner : MonoBehaviour {
    public int municion = 100;
    public float speed = 3f;
    public float timer = 5f;
    public GameObject bubbles;
    public GameObject[] balasArray;
    public Queue<Transform> muniQueue = new Queue<Transform>();
    public static MuniSpawner muniSpawner;

	// Use this for initialization
	void Start () {
        muniSpawner = this.GetComponent<MuniSpawner> ();

        for(int i = 0; i<municion; i++)
        {
            GameObject muni = Instantiate(bubbles, transform.position, Quaternion.identity) as GameObject;
            Transform trans = muni.GetComponent<Transform>();
            trans.parent = GetComponent<Transform>();
            muniQueue.Enqueue(trans);
            muni.SetActive(false);
            balasArray[i] = muni;
        }

		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position += transform.right * speed * Time.deltaTime;
        Invoke("Destroy", timer);

    }

    public static Transform spm (Quaternion rotation, Vector3 position)
    {
        Transform muni = muniSpawner.muniQueue.Dequeue();
        muni.gameObject.SetActive(true);
        muni.position = position;
        muni.rotation = rotation;
        muniSpawner.muniQueue.Enqueue(muni);

        return muni;
    }

    public void Destroy()
    {
        transform.position = transform.parent.position;
        gameObject.SetActive(false);
        
    }
}
