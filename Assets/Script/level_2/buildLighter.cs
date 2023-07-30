using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildLighter : MonoBehaviour {
	public GameObject flintstone, fuel, body, lighter;
	public static bool usedFlintstone, usedFuel, built;
	public GameObject text;

	void Start(){
		usedFlintstone = false; usedFuel = false; built = false;
	}

	void OnTriggerEnter(Collider other) {
		if(!lv2_logic_control.gotLighter){
			if (lv2_item_control.num == 1 && lv2_item_control.item [1]) {
				text.GetComponent<GUIText> ().text = "Right Click: Put down flintstone";
			} else if (lv2_item_control.num == 2 && lv2_item_control.item [2]) {
				text.GetComponent<GUIText> ().text = "Right Click: Put down fuel";
			} else if (built) {
				text.GetComponent<GUIText> ().text = "Left  Click: Take";
			} else if (usedFlintstone && usedFuel) {
				text.GetComponent<GUIText> ().text = "Left  Click: Build";
			} else {
				text.GetComponent<GUIText> ().text = "Part of a gold lighter\nWhere are the other parts...";
			}
			text.SetActive (true);
		}
	}

	void OnTriggerStay(Collider other) {
		if (!lv2_logic_control.gotLighter) {
			if (built) {
				text.GetComponent<GUIText> ().text = "Left  Click: Take";
				if (Input.GetMouseButtonDown (0)) {
					DestroyObject (lighter);
					lv2_logic_control.gotLighter = true;
					lv2_item_control.item [3] = true;
					text.SetActive (false);
				}
			} else if (usedFlintstone && usedFuel) {
				text.GetComponent<GUIText> ().text = "Left  Click: Build";
				if (Input.GetMouseButtonDown (0)) {
					DestroyObject (flintstone);
					DestroyObject (fuel);
					DestroyObject (body);
					lighter.SetActive (true);
					built = true;
				}
			} else if (lv2_item_control.num == 1 && lv2_item_control.item [1]) {
				text.GetComponent<GUIText> ().text = "Right Click: Put down flintstone";
				if (Input.GetMouseButtonDown (1)) {
					flintstone.SetActive (true);
					usedFlintstone = true;
					lv2_item_control.item [1] = false;
					text.GetComponent<GUIText> ().text = "";
				}
			} else if (lv2_item_control.num == 2 && lv2_item_control.item [2]) {
				text.GetComponent<GUIText> ().text = "Right Click: Put down fuel";
				if (Input.GetMouseButtonDown (1)) {	
					fuel.SetActive (true);
					usedFuel = true;
					lv2_item_control.item [2] = false;
					text.GetComponent<GUIText> ().text = "";
				}
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		text.SetActive (false);
	}
}
