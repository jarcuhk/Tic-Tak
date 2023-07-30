using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class timer : MonoBehaviour {
	public GameObject text;
	public static float timeLeft;
	//public static bool switched;
	//public static bool gg;

	// Use this for initialization
	void Start () {
		timeLeft = 90.0f;
		//ggText.SetActive (false);
		//switched = false;
	}

	// Update is called once per frame
	void Update () {
		/*
		if (!logic_control.door_opened) {
			timeLeft -= Time.deltaTime;
			text.GetComponent<GUIText> ().text = "Time Left:" + Mathf.Round (timeLeft);
			if (timeLeft < 0) {
				ggText.SetActive (true);
				logic_control.gg = true;
			}
		} else if (logic_control.door_opened && !logic_control.escaped) {
			
			}
		}
		else {
			text.SetActive (false);
		}
		*/
		if (!logic_control.gg) {
			timeLeft -= Time.deltaTime;
			text.GetComponent<GUIText> ().text = "Time Left:" + Mathf.Round (timeLeft);
			if (timeLeft < 0) {
				logic_control.gg = true;
				Screen.lockCursor = false;
				SceneManager.LoadScene (4);
			}
		}
	}
}
