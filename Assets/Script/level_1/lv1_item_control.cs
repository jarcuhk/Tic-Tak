using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lv1_item_control : MonoBehaviour {
	//public static bool key, statueKey, crowbar;
	//public static bool eye1, eye2, nose1, nose2, mouth;
	public static bool[] item;
	public static int num;
	public string[] itemTitle;
	public GameObject text;

	void Start()
	{
		item = new bool[8];
		for (int i = 0; i < 7; i++)
			item [i] = false;
		//key = false; statueKey = false; crowbar = false;
		//eye1 = false; eye2 = false; nose1 = false; nose2 = false; mouth = false;
		num = 0;

		itemTitle = new string[8];
		itemTitle [0] = "Key";
		itemTitle [1] = "Sliver Key";
		itemTitle [2] = "Crowbar";
		itemTitle [3] = "Gem";
		itemTitle [4] = "Gem";
		itemTitle [5] = "Ring";
		itemTitle [6] = "Ring";
		itemTitle [7] = "Ancient coin";

		/*item [3] = true;
		item [4] = true;
		item [5] = true;
		item [6] = true;
		item [7] = true;*/
	}

	void Update()
	{
		if(Input.GetAxis("Mouse ScrollWheel") != 0f){
			if(Input.GetAxis("Mouse ScrollWheel") > 0f){
				if (num < 7) {
					for (int i = 1; i < 8 - num; i++) {
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
		else if (Input.GetKeyDown (KeyCode.Alpha6))
			num = 5;
		else if (Input.GetKeyDown (KeyCode.Alpha7))
			num = 6;
		else if (Input.GetKeyDown (KeyCode.Alpha8))
			num = 7;

		if (item [num]) {
			text.GetComponent<GUIText> ().text = "Item: " + itemTitle [num];
		} else {
			text.GetComponent<GUIText> ().text = "Item: ";
		}
	}
}