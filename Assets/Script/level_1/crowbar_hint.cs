using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crowbar_hint : MonoBehaviour {
	public GameObject text;

	// Use this for initialization
	void Start () {
		text.SetActive (false);
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			if (!logic_control.carpet_moved)
			{
				text.GetComponent<GUIText> ().text = "Watch your steps!";
				text.SetActive (true);
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		text.GetComponent<GUIText> ().text = "";
	}
}