using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openOfficeDoor : MonoBehaviour {
	public GameObject text, door;
	bool opened;

	void Start(){
		opened = false;
	}

	void OnTriggerEnter(Collider other){
		if (!opened) {
			text.GetComponent<GUIText> ().text = "Left Click: Open door";
		}
	}

	void OnTriggerStay(Collider other){
		if (Input.GetMouseButtonDown (0) && !opened)
		{
			door.GetComponent<Animator> ().SetBool ("open", true);
			text.GetComponent<GUIText> ().text = "";
			opened = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		text.GetComponent<GUIText> ().text = "";
	}
}
