using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class botones : MonoBehaviour {

	public void PlayGame()
    {
        SceneManager.LoadScene("scene1");
    }
}
