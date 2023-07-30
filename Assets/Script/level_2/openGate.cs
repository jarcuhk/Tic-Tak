using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openGate : MonoBehaviour {
	public GameObject door, text;
	public AudioSource se;

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player" && !lv2_logic_control.openedGate) {
			if (lv2_item_control.item [4] && lv2_item_control.num == 4) {
				text.GetComponent<GUIText> ().text = "Right Click: Unlock";
			} else {
				text.GetComponent<GUIText> ().text = "This gate is locked";
			}
			text.SetActive (true);
		}
	}

	void OnTriggerStay(Collider other) {
		if (other.tag == "Player" && !lv2_logic_control.openedGate) {
			if (lv2_item_control.item [4] && lv2_item_control.num == 4) {
				text.GetComponent<GUIText> ().text = "Right Click: Unlock";

				if (Input.GetMouseButtonDown (1)) {
					door.GetComponent<Animator> ().SetBool ("open", true);
					se.Play ();
					lv2_logic_control.openedGate = true;
				}
			} else {
				text.GetComponent<GUIText> ().text = "This gate is locked";
			}
		}
	}

	void OnTriggerExit(Collider other){
		text.SetActive (false);
	}
}
