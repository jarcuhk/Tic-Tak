using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class safebox : MonoBehaviour {
	public GameObject door, key, text;

	GameObject[,] lights;
	public GameObject y1, y2, y3, y4;
	public GameObject g1, g2, g3, g4;
	public GameObject r1, r2, r3, r4;

	private KeyCode[] keycodes;
	int[] input = { 0, 0, 0, 0 };
	int[] answer = { 3, 4, 5, 4 };
	int count = 0;
	bool[] correct = new bool[4];

	void Start () {
		lights = new GameObject[4, 3];

		lights [0, 0] = y1;
		lights [1, 0] = y2;
		lights [2, 0] = y3;
		lights [3, 0] = y4;

		lights [0, 1] = g1;
		lights [1, 1] = g2;
		lights [2, 1] = g3;
		lights [3, 1] = g4;

		lights [0, 2] = r1;
		lights [1, 2] = r2;
		lights [2, 2] = r3;
		lights [3, 2] = r4;

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

		for (int i = 0; i < 4; i++)
			correct [i] = false;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			if (lv2_logic_control.playDisc)
			{
				if (!lv2_logic_control.safeOpen) {
					text.GetComponent<GUIText> ().text = "Keyboard: Input password";
					text.SetActive (true);
				} else if (!lv2_logic_control.gotKey) {
					text.GetComponent<GUIText> ().text = "A key\nLeft Click: Take";
					text.SetActive (true);
				}
			}
		}
	}

	void check()
	{
		for (int i = 0; i < 4; i++) {
			if (input [i] != 0) {
				Debug.Log ("checking: ans["+i+"]="+answer[i]+",input["+i+"]="+input [i]);

				lights [i, 0].SetActive (false);
				Debug.Log ("Light " + i + " 0 to false");

				if (answer [i] == input [i]) {
					lights [i, 1].SetActive (true);
					Debug.Log ("Light " + i + " 1 to true");
					correct [i] = true;
				} else {
					lights [i, 2].SetActive (true);
					Debug.Log ("Light " + i + " 2 to true");
					correct [i] = false;
				}
			}
		}
	}

	bool checkAll()
	{
		for (int i = 0; i < 4; i++)
			if (!correct [i])
				return false;
		return true;
	}

	void reset()
	{
		for (int i = 0; i < 4; i++) {
			Debug.Log ("reseting anim: " + i + "," + input [i].ToString ());
			lights [i, 0].SetActive (true);
			lights [i, 1].SetActive (false);
			lights [i, 2].SetActive (false);
			input[i] = 0;
			correct [i] = false;
		}

		count = 0;
		Debug.Log ("Reset");
	}

	void OnTriggerStay(Collider other){
		if (other.tag == "Player" && lv2_logic_control.playDisc && !lv2_logic_control.safeOpen) {
			if (count < 4) {
				for (int i = 0; i < 9; i++) {
					if (Input.GetKeyDown (keycodes [i])) {
						Debug.Log (keycodes [i].ToString ());
						input [count] = i + 1;
						check ();
						if (count < 4)
							count++;
					}
				}
			} else {
				string myString = "";
				for (int i = 0; i < 4; i++)
					myString += input [i] + ",";
				Debug.Log ("Input: " + myString);
				if (checkAll ()) {
					text.GetComponent<GUIText> ().text = "Correct!";
					door.GetComponent<Animator> ().SetBool ("open", true);
					StartCoroutine (waitToTake ());
				} else
					reset ();
			}
		} else if (other.tag == "Player" && lv2_logic_control.safeOpen && !lv2_logic_control.gotKey) {
			if (Input.GetMouseButtonDown (0)) {
				DestroyObject (key);
				text.SetActive (false);
				lv2_item_control.item [4] = true;
				lv2_logic_control.gotKey = true;
			}
		}
	}

	IEnumerator waitToTake()
	{
		yield return new WaitForSeconds (2.0f);
		text.GetComponent<GUIText> ().text = "A key\nLeft Click: Take";
		lv2_logic_control.safeOpen = true;
	}

	void OnTriggerExit(Collider other)
	{
		if (!logic_control.password_shown && !logic_control.password_correct)
			reset ();
		text.SetActive (false);
	}
}
