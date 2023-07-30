using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightUp : MonoBehaviour {
	public GameObject text, fire;
	public int index;

	void Start(){
		//fire.GetComponent<ParticleSystem> ().Stop ();
	}

	void OnTriggerEnter(Collider other){
		if (!lv2_logic_control.lighted [index]) {
			if (lv2_item_control.item [3] && lv2_item_control.num == 3) {
				text.GetComponent<GUIText> ().text = "Right Click: Light up";
			} else {
				text.GetComponent<GUIText> ().text = "A candle\nmaybe light it on?";
			}
			text.SetActive (true);
		}
	}

	void OnTriggerStay(Collider other){
		if (!lv2_logic_control.lighted [index]) {
			text.GetComponent<GUIText> ().text = "A candle\nmaybe light it on?";

			if (lv2_item_control.item [3] && lv2_item_control.num == 3) {
				text.GetComponent<GUIText> ().text = "Right Click: Light up";

				if (Input.GetMouseButtonDown (1)) {
					fire.GetComponent<ParticleSystem> ().Play ();
					lv2_logic_control.lighted [index] = true;
					text.SetActive (false);
				}
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		text.SetActive (false);
	}
}
