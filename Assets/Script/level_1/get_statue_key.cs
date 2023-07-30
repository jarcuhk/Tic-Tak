using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class get_statue_key : MonoBehaviour {
	public GameObject key, text;
	//public static bool key_token;
	public AudioSource se;

	// Use this for initialization
	void Start () {
		text.SetActive (false);
	}
	
	// Update is called once per frame
	void OnTriggerEnter(Collider other)
	{
		if (!logic_control.skull_key_token) {
			text.GetComponent<GUIText> ().text = "A sliver made key\nBy the size, seems it's for big business\nLeft Click: Take";
			text.SetActive (true);
		}
	}

	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player" && Input.GetMouseButtonDown (0) && !logic_control.skull_key_token)
		{
			text.SetActive (false);
			se.Play ();
			lv1_item_control.item[1] = true;
			logic_control.skull_key_token = true;
			DestroyObject (key);
		}
	}

	void OnTriggerExit(Collider other)
	{
		text.SetActive (false);
	}
}