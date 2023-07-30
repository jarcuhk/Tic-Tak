using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turn_frog : MonoBehaviour
{
	public GameObject frog, eye1, eye2, nose1, nose2, mouth, text;
	public static bool eye1_pluged, eye2_pluged, nose1_pluged, nose2_pluged, mouth_pluged;
	public AudioSource se;
	bool tried = false;

	// Use this for initialization
	void Start () {
		eye1.SetActive (false);
		eye2.SetActive (false);
		nose1.SetActive (false);
		nose2.SetActive (false);
		mouth.SetActive (false);
		text.SetActive (false);

		eye1_pluged = false; eye2_pluged = false;
		nose1_pluged = false; nose2_pluged = false;
		mouth_pluged = false;
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			if (!logic_control.frog_turned)
			{
				text.GetComponent<GUIText> ().text = "Left Click: Turn";
				text.SetActive (true);
			}
		}
	}

	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player" && !logic_control.frog_turned) {
			if (lv1_item_control.num == 3 || lv1_item_control.num == 4
				|| lv1_item_control.num == 5 || lv1_item_control.num == 6
				|| lv1_item_control.num == 7) {
				if (lv1_item_control.item [3] || lv1_item_control.item [4]
					|| lv1_item_control.item [5] || lv1_item_control.item [6]
					|| lv1_item_control.item [7]) {
					text.GetComponent<GUIText> ().text = "Right Click: Plug";
					if (Input.GetMouseButtonDown (1)) {
						switch (lv1_item_control.num) {
						case 3:
							if (lv1_item_control.item[3] && !eye1_pluged)
							{
								eye1.SetActive (true);
								eye1_pluged = true;
								lv1_item_control.item[3] = false;
							}
							break;
						case 4:
							if (lv1_item_control.item[4] && !eye2_pluged) {
								eye2.SetActive (true);
								eye2_pluged = true;
								lv1_item_control.item[4] = false;
							}
							break;
						case 5:
							if (lv1_item_control.item[5] && !nose1_pluged) {
								nose1.SetActive (true);
								nose1_pluged = true;
								lv1_item_control.item[5] = false;
							}
							break;
						case 6:
							if (lv1_item_control.item[6] && !nose2_pluged) {
								nose2.SetActive (true);
								nose2_pluged = true;
								lv1_item_control.item[6] = false;
							}
							break;
						case 7:
							if (lv1_item_control.item[7] && !mouth_pluged) {
								mouth.SetActive (true);
								mouth_pluged = true;
								lv1_item_control.item[7] = false;
							}
							break;
						default:
							text.GetComponent<GUIText> ().text = "It's not useful in this case";
							break;
						}
						text.GetComponent<GUIText> ().text = "";
					}
				}
			} else {
				if (!tried) {
					text.GetComponent<GUIText> ().text = "Left Click: Turn";
				} else {
					text.GetComponent<GUIText> ().text = "No response\nDo I have anything useful?";
				}
				if (Input.GetMouseButtonDown (0)) {
					if (eye1_pluged && eye2_pluged
					    && nose1_pluged && nose2_pluged
					    && mouth_pluged) {
						frog.GetComponent<Animator> ().SetBool ("turn", true);
						se.Play ();
						logic_control.frog_turned = true;
						text.SetActive (false);
					} else {
						text.GetComponent<GUIText> ().text = "No response\nDo I have anything useful?";
						tried = true;
					}
				}
			}
		}

		/*if (other.tag == "Player")
		{
			if (!logic_control.frog_turned)
			{
				if (Input.GetMouseButtonDown (0)) {
					if (eye1_pluged && eye2_pluged
					    && nose1_pluged && nose2_pluged
					    && mouth_pluged) {
						frog.GetComponent<Animator> ().SetBool ("turn", true);
						se.Play ();
						logic_control.frog_turned = true;
						text.SetActive (false);
					} else {
						if (lv1_item_control.item[3] || lv1_item_control.item[4]
							|| lv1_item_control.item[5] || lv1_item_control.item[6]
						   || lv1_item_control.item[7])
							text.GetComponent<GUIText> ().text = "No response\nDo I have anything useful?";
						else
							text.GetComponent<GUIText> ().text = "Can't turn the statue\nWhat are these holes use for?";
					}
				} else if (Input.GetMouseButtonDown (1)) {
					switch (lv1_item_control.num) {
					case 3:
						if (lv1_item_control.item[3] && !eye1_pluged)
						{
							eye1.SetActive (true);
							eye1_pluged = true;
							lv1_item_control.item[3] = false;
						}
						break;
					case 4:
						if (lv1_item_control.item[4] && !eye2_pluged) {
							eye2.SetActive (true);
							eye2_pluged = true;
							lv1_item_control.item[4] = false;
						}
						break;
					case 5:
						if (lv1_item_control.item[5] && !nose1_pluged) {
							nose1.SetActive (true);
							nose1_pluged = true;
							lv1_item_control.item[5] = false;
						}
						break;
					case 6:
						if (lv1_item_control.item[6] && !nose2_pluged) {
							nose2.SetActive (true);
							nose2_pluged = true;
							lv1_item_control.item[6] = false;
						}
						break;
					case 7:
						if (lv1_item_control.item[7] && !mouth_pluged) {
							mouth.SetActive (true);
							mouth_pluged = true;
							lv1_item_control.item[7] = false;
						}
						break;
					default:
						text.GetComponent<GUIText> ().text = "It's not useful in this case";
						break;
					}
				}
			}
		}*/
	}

	void OnTriggerExit(Collider other)
	{
		text.SetActive (false);
		tried = false;
	}
}
