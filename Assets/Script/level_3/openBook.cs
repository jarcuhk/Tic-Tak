using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openBook : MonoBehaviour {
	public GameObject close, open, text;

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player" && !lv3_logic_control.bookOpened) {
			text.GetComponent<GUIText> ().text = "This book's cover is weird\nLeft Click: Open";
		}
	}

	void OnTriggerStay(Collider other) {
		if (other.tag == "Player" && !lv3_logic_control.bookOpened) {
			text.GetComponent<GUIText> ().text = "This book's cover is weird\nLeft Click: Open";

			if (Input.GetMouseButtonDown (0)) {
				DestroyObject (close);
				open.SetActive (true);
				text.GetComponent<GUIText> ().text = "";
				lv3_logic_control.bookOpened = true;
			}
		}
	}

	void OnTriggerExit(Collider other) {
		text.GetComponent<GUIText> ().text = "";
	}
}
