using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class get_key : MonoBehaviour {
	public GameObject key;
	//public GameObject button;
	//public static bool key_token;
	public GameObject text;
	public AudioSource se;
	//public static bool button_pressed;

	// Use this for initialization
	void Start () {
		key.SetActive (false);
		text.SetActive (false);
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (!logic_control.first_key_token && logic_control.button_pressed) {
			text.GetComponent<GUIText> ().text = "A key\nLeft Click: Take";
			text.SetActive (true);
		}
	}

	void OnTriggerStay(Collider other)
	{
		//Debug.Log ("player in");

		if (Input.GetMouseButtonDown (0)
			&& logic_control.first_key_token == false
			&& logic_control.button_pressed)
		{
			DestroyObject (key);
			se.Play();
			text.SetActive (false);
			logic_control.first_key_token = true;
			lv1_item_control.item[0] = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		text.SetActive (false);
	}
}