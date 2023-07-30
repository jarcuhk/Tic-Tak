using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lv3_item_control : MonoBehaviour {
	public static bool[] item;
	public static int num;
	string[] itemTitle;
	public GameObject text;

	void Start () {
		item = new bool[1];
		item [0] = false;
		num = 0;


		itemTitle = new string[1];
		itemTitle [0] = "Sheet Music";
		//itemTitle [1] = "Tic Tak";

		//item [3] = true;
	}

	void Update () {
		/*if(Input.GetAxis("Mouse ScrollWheel") != 0f){
			if(Input.GetAxis("Mouse ScrollWheel") > 0f){
				if (num < 1) {
					for (int i = 1; i < 2 - num; i++) {
						if (item [num + i]) {
							num += i;
							break;
						}
					}
				}
			}
			if(Input.GetAxis("Mouse ScrollWheel") < 0f){
				if (num > 0) {
					for (int i = 1; i <= num; i++) {
						if (item [num - i]) {
							num -= i;
							break;
						}
					}
				}
			}   
		}

		if (Input.GetKeyDown (KeyCode.Alpha1))
			num = 0;*/

		if (item [num]) {
			text.GetComponent<GUIText> ().text = "Item: " + itemTitle [num];
		} else {
			text.GetComponent<GUIText> ().text = "Item: ";
		}
	}
}
