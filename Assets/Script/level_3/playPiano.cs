using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playPiano : MonoBehaviour {
	public GameObject text, sheet;
	public AudioSource se;

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player" && !lv3_logic_control.playedPiano) {
			if (lv3_item_control.item [0] && lv3_item_control.num == 0)
				text.GetComponent<GUIText> ().text = "Right Click: Set";
			else
				text.GetComponent<GUIText> ().text = "I don't know how to play piano";
		}
	}

	void OnTriggerStay(Collider other) {
		if (other.tag == "Player" && !lv3_logic_control.playedPiano) {
			if (lv3_item_control.item [0] && lv3_item_control.num == 0) {
				text.GetComponent<GUIText> ().text = "Right Click: Set";

				if (Input.GetMouseButtonDown (1)) {
					sheet.SetActive (true);
					text.GetComponent<GUIText> ().text = "It activate something\nThe piano is playing itself";
					se.Play ();
					lv3_logic_control.playedPiano = true;
				}
			}
			else
				text.GetComponent<GUIText> ().text = "I don't know how to play piano";
		}
	}

	void OnTriggerExit(Collider other) {
		text.GetComponent<GUIText> ().text = "";
	}
}
