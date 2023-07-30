using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getSheet : MonoBehaviour {
	public GameObject text, sheet;

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player" && !lv3_item_control.item [0]) {
			text.GetComponent<GUIText>().text="A piece of sheet music\nLeft Click: Take";
		}
	}

	void OnTriggerStay(Collider other){
		if (other.tag == "Player" && !lv3_item_control.item [0]) {
			text.GetComponent<GUIText>().text="A piece of sheet music\nLeft Click: Take";

			if(Input.GetMouseButtonDown (0)){
				lv3_item_control.item[0] = true;
				DestroyObject(sheet);
				text.GetComponent<GUIText> ().text = "";
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		text.GetComponent<GUIText> ().text = "";
	}
}
