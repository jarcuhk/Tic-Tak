﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class get_eye2 : MonoBehaviour {
	public GameObject plug, text;

	// Use this for initialization
	void Start () {
		text.SetActive (false);
	}

	void OnTriggerEnter(Collider other)
	{
		if (logic_control.plugs_showed && !logic_control.eye2_token && other.tag == "Player")
		{
			text.GetComponent<GUIText> ().text = "A shiny gem\nLeft Click: Take";
			text.SetActive (true);
		}
	}

	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player" && logic_control.plugs_showed && !logic_control.eye2_token && Input.GetMouseButtonDown(0))
		{
			Destroy (plug);
			logic_control.eye2_token = true;
			lv1_item_control.item[4] = true;
			text.SetActive (false);
		}
	}

	void OnTriggerExit(Collider other)
	{
		text.SetActive (false);
	}
}
