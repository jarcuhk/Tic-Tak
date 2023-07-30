using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playDisc : MonoBehaviour {
	public GameObject oldSpeaker, newSpeaker, JohnsBigD;
	public GameObject text;
	public AudioSource se;

	void Start () {
		text.SetActive (false);
	}

	void OnTriggerEnter(Collider other)
	{
		if (!lv2_logic_control.playDisc) {
			if (lv2_item_control.item [0]) {
				if (lv2_item_control.num == 0) {
					text.GetComponent<GUIText> ().text = "Right Click: Play";
				} else {
					text.GetComponent<GUIText> ().text = "The record can play here";
				}
			} else {
				text.GetComponent<GUIText> ().text = "This gramophone seems old but still works\nit cannot play anything without a record";
			}
			text.SetActive (true);
		}
	}

	void OnTriggerStay(Collider other)
	{
		if (!lv2_logic_control.playDisc){
			if (lv2_item_control.item [0]) {
				if (lv2_item_control.num == 0) {
					text.GetComponent<GUIText> ().text = "Right Click: Play";

					if (Input.GetMouseButtonDown (1)) {
						DestroyObject (oldSpeaker);
						newSpeaker.SetActive (true);
						text.SetActive (false);
						lv2_item_control.item [0] = false;
						se.Play ();
						lv2_logic_control.playDisc = true;

						JohnsBigD.GetComponent<Animator> ().SetBool ("move", true);
					}
				} else {
					text.GetComponent<GUIText> ().text = "The record can play here";
				}
			} else {
				text.GetComponent<GUIText> ().text = "This gramophone seems old but still works\nit cannot play anything without a record";
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		text.GetComponent<GUIText> ().text = "";
	}
}
