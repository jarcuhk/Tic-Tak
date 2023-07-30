using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lv2_item_control : MonoBehaviour {
	public static bool[] item;
	public static int num;
	string[] itemTitle;
	public GameObject text;

	void Start () {
		item = new bool[5];
		for (int i = 0; i < 4; i++)
			item [i] = false;
		//item [5] = true;
		//num = 5;


		itemTitle = new string[6];
		itemTitle [0] = "Disc";
		itemTitle [1] = "Flintstone";
		itemTitle [2] = "Fuel";
		itemTitle [3] = "Lighter";
		itemTitle [4] = "Key";
		//itemTitle [5] = "Tic Tak";

		//item [3] = true;
	}

	void Update () {
		if(Input.GetAxis("Mouse ScrollWheel") != 0f){
			if(Input.GetAxis("Mouse ScrollWheel") > 0f){
				if (num < 5) {
					for (int i = 1; i < 6 - num; i++) {
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
			num = 0;
		else if (Input.GetKeyDown (KeyCode.Alpha2))
			num = 1;
		else if (Input.GetKeyDown (KeyCode.Alpha3))
			num = 2;
		else if (Input.GetKeyDown (KeyCode.Alpha4))
			num = 3;
		else if (Input.GetKeyDown (KeyCode.Alpha5))
			num = 4;

		if (item [num]) {
			text.GetComponent<GUIText> ().text = "Item: " + itemTitle [num];
		} else {
			text.GetComponent<GUIText> ().text = "Item: ";
		}
	}
}
