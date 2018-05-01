using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EasterEgg;

/// <summary>
/// This demo shows how to use the Egg plugin
/// </summary>
public class GameEngineSample : MonoBehaviour {

	public Text SecretText;

	/// <summary>
	/// Ths test method we will use as callback for easter egg
	/// </summary>
	public void TestMethod () {
		Debug.Log("Invoke test method!");
		SecretText.enabled = true;
	}

	void Start () {
		var sequence = new List<KeyCode> () { 
			KeyCode.LeftArrow, KeyCode.E, KeyCode.G, KeyCode.G, KeyCode.UpArrow
		};

		// You can use Egg this way
		Egg.Instance.ListenTo (sequence, () => Debug.Log("Anonymous callback!"));

		// OR this way (checked with Unity 5.5). If this throw an error you can use the method above
		Egg.Instance.ListenTo (sequence, TestMethod);

		// Pass the sequence name if you would like to stop and/or resume the listeners later
		// It's possible to create several sequences with the same name
		Egg.Instance.ListenTo ("Main Cheat", sequence, TestMethod);

		// Pause (remove) listener by the sequence name
		Egg.Instance.StopListen("Main Cheat");

		// Resume listener by the sequence name
		Egg.Instance.ResumeListen("Main Cheat");
	}
}