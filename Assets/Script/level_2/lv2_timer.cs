using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lv2_timer : MonoBehaviour {
	public GameObject text;
	public static float timeLeft;

	void Start () {
		timeLeft = 300.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (!lv2_logic_control.gg) {
			timeLeft -= Time.deltaTime;
			text.GetComponent<GUIText> ().text = "Time Left:" + Mathf.Round (timeLeft);
			if (timeLeft < 0) {
				lv2_logic_control.gg = true;
				Screen.lockCursor = false;
				SceneManager.LoadScene (7);
			}
		}
	}
}
