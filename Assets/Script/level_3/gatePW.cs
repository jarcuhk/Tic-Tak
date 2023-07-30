using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gatePW : MonoBehaviour {
	public GameObject gate, text;

	GameObject[,] lights;
	public GameObject r1, r2, r3, r4, r5, r6, r7, r8, r9;
	public GameObject g1, g2, g3, g4, g5, g6, g7, g8, g9;

	private KeyCode[] keycodes;
	int[] input = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
	int[] answer = { 6, 5, 4, 7, 8, 9, 6, 3, 2, 1 };
	int count = 0;
	//bool[] correct = new bool[10];

	/*
	7 8 9	6 7 8
	4 5 6	3 4 5
	1 2 3	0 1 2
	*/

	void Start () {
		lights = new GameObject[9, 2];

		lights [0, 0] = r1;
		lights [1, 0] = r2;
		lights [2, 0] = r3;
		lights [3, 0] = r4;
		lights [4, 0] = r5;
		lights [5, 0] = r6;
		lights [6, 0] = r7;
		lights [7, 0] = r8;
		lights [8, 0] = r9;

		lights [0, 1] = g1;
		lights [1, 1] = g2;
		lights [2, 1] = g3;
		lights [3, 1] = g4;
		lights [4, 1] = g5;
		lights [5, 1] = g6;
		lights [6, 1] = g7;
		lights [7, 1] = g8;
		lights [8, 1] = g9;

		keycodes = new KeyCode[9];

		keycodes [0] = KeyCode.Keypad1;
		keycodes [1] = KeyCode.Keypad2;
		keycodes [2] = KeyCode.Keypad3;
		keycodes [3] = KeyCode.Keypad4;
		keycodes [4] = KeyCode.Keypad5;
		keycodes [5] = KeyCode.Keypad6;
		keycodes [6] = KeyCode.Keypad7;
		keycodes [7] = KeyCode.Keypad8;
		keycodes [8] = KeyCode.Keypad9;

		//for (int i = 0; i < 10; i++)
		//	correct [i] = false;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			if (lv3_logic_control.playedPiano && !lv3_logic_control.gateOpened) {
				text.GetComponent<GUIText> ().text = "Keyboard: Input password";
			}
		}
	}

	bool check(int n)
	{
		if (input [n] == answer [n]) {
			return true;
		}
		return false;
	}

	void reset()
	{
		for (int i = 0; i < 9; i++) {
			Debug.Log ("reseting anim: " + i + "," + input [i].ToString ());
			lights [i, 1].SetActive (false);
			lights [i, 0].SetActive (true);
			input[i] = 0;
			//correct [i] = false;
		}

		count = 0;
		Debug.Log ("Reset");
	}

	void OnTriggerStay(Collider other){
		if (other.tag == "Player" && lv3_logic_control.playedPiano && !lv3_logic_control.gateOpened) {
			text.GetComponent<GUIText> ().text = "Keyboard: Input password";
			if (count < 10) {
				for (int i = 0; i < 9; i++) {
					if (Input.GetKeyDown (keycodes [i])) {
						Debug.Log (keycodes [i].ToString ());
						input [count] = i + 1;
						if (check (count)) {
							if (lights [i, 0].activeSelf) {
								lights [i, 0].SetActive (false);
								lights [i, 1].SetActive (true);
							}
							count++;
						} else {
							reset ();
						}
					}
				}
			} else {
				lv3_logic_control.gateOpened = true;
				gate.GetComponent<Animator> ().SetBool ("open", true);
				text.GetComponent<GUIText> ().text = "";
			}
		}
	}

	void OnTriggerExit(Collider other){
		if (other.tag == "Player" && lv3_logic_control.playedPiano && !lv3_logic_control.gateOpened) {
			reset ();
			text.GetComponent<GUIText> ().text = "";
		}
	}
}