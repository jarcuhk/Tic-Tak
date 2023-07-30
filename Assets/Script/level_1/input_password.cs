using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class input_password : MonoBehaviour {
	public GameObject pad, text;
	GameObject[] keys;
	bool[] pressed;
	private KeyCode[] keycodes;
	int[] input = { 0, 0, 0 };
	int[] answer = { 4, 2, 9 };
	int count = 0;
	GameObject[,] letters;
	public GameObject r1, r2, u1, u2, n1, n2;
	bool[] correct = new bool[3];
	Animator anim;

	// Use this for initialization
	void Start () {
		keys = new GameObject[9];

		keys [0] = GameObject.Find ("BoxNum1");
		keys [1] = GameObject.Find ("BoxNum2");
		keys [2] = GameObject.Find ("BoxNum3");
		keys [3] = GameObject.Find ("BoxNum4");
		keys [4] = GameObject.Find ("BoxNum5");
		keys [5] = GameObject.Find ("BoxNum6");
		keys [6] = GameObject.Find ("BoxNum7");
		keys [7] = GameObject.Find ("BoxNum8");
		keys [8] = GameObject.Find ("BoxNum9");

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

		letters = new GameObject[3, 2];

		letters [0, 0] = r1;
		letters [0, 1] = r2;
		letters [1, 0] = u1;
		letters [1, 1] = u2;
		letters [2, 0] = n1;
		letters [2, 1] = n2;

		/*
		letters [0, 0] = GameObject.Find ("R");
		letters [0, 1] = GameObject.Find ("R(Gold)");
		letters [1, 0] = GameObject.Find ("U");
		letters [1, 1] = GameObject.Find ("U(Gold)");
		letters [2, 0] = GameObject.Find ("N");
		letters [2, 1] = GameObject.Find ("N(Gold)");
		*/

		letters [0, 1].SetActive (false);
		letters [1, 1].SetActive (false);
		letters [2, 1].SetActive (false);

		for (int i = 0; i < 3; i++)
			correct [i] = false;

		pressed = new bool[9];
		for (int i = 0; i < 3; i++)
			pressed [i] = false;

		anim = pad.GetComponent<Animator> ();
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			if (logic_control.password_shown && !logic_control.password_correct)
			{
				text.GetComponent<GUIText> ().text = "Keyboard: Input";
				text.SetActive (true);
			}
		}
	}

	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player" && !logic_control.password_correct && logic_control.password_shown) {
			if (count < 3) {
				for (int i = 0; i < 9; i++) {
					if (Input.GetKeyDown (keycodes [i]) && !pressed [i]) {
						Debug.Log(keycodes[i].ToString());
						int n = i + 1;
						//anim.SetBool (n.ToString (), true);
						anim.Play("Num" + n + "Down");
						pressed[i] = true;
						input [count] = i + 1;
						check();
						if (count < 3)
							count++;
					}
				}
			}else{
				string myString = "";
				for (int i = 0; i < 3; i++)
					myString += input[i] + ",";
				Debug.Log("Input: " + myString);
				if (checkAll ()) {
					text.GetComponent<GUIText> ().text = "Correct!";
					logic_control.password_correct = true;
				}
				else
					reset ();
			}

			/*
			while (count < 3) {
				input [count] = press ();
				check ();
			}
			if (checkAll ())
				logic_control.password_correct = true;
			else
				reset ();
			
			do {
				pressed[count] = press();
				check(count, pressed[count]);
				count++;
			} while(count < 3);

			if (pressed.Equals (answer)) {
				logic_control.password_correct = true;
			} else {
				reset ();
			}

			if (Input.GetKeyDown (KeyCode.Keypad4) || Input.GetKeyDown (KeyCode.Alpha4)) {
				letters [0, 0].SetActive (false); letters [0, 1].SetActive (true);
				correct [0] = true;
			}
			*/
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (!logic_control.password_shown && !logic_control.password_correct)
			reset ();
		text.SetActive (false);
	}

	int press()
	{
		for (int i = 0; i < 9; i++) {
			if (Input.GetKeyDown (keycodes [i])) {
				//anim.SetBool ((i + 1).ToString(), true);
				count++;
				return i + 1;
			}
		}
		return 0;
	}

	void check()
	{
		for (int i = 0; i < 3; i++) {
			Debug.Log ("checking: ans[" + i + "]=" + answer [i] + ",input[" + i + "]=" + input [i]);
			
			if (answer [i] == input [i]) {
				//if (letters [i, 0].activeSelf) {
				letters [i, 0].SetActive (false);
				Debug.Log ("Letter " + i + " 0 to false");
				letters [i, 1].SetActive (true);
				Debug.Log ("Letter " + i + " 1 to true");
				//}
				correct [i] = true;
			}
		}
	}

	bool checkAll()
	{
		for (int i = 0; i < 3; i++)
			if (!correct [i])
				return false;
		return true;
	}

	void reset()
	{
		for (int i = 0; i < 3; i++) {
			//anim.SetBool (input [i].ToString (), false);
			//anim.Play("Num" + input [i] + "Up");
			Debug.Log ("reseting anim: " + i + "," + input [i].ToString ());
			letters [i, 0].SetActive (true);
			letters [i, 1].SetActive (false);
			input[i] = 0;
			correct [i] = false;
		}
		for (int i = 0; i < 9; i++)
			pressed [i] = false;
		count = 0;
		Debug.Log ("Reset");
	}
}