using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openCabinet : MonoBehaviour {
	public GameObject cabinet, text;
	bool clicked = false;
	
	void OnTriggerEnter(Collider other){
		if (!lv2_logic_control.openCabinet) {
			text.GetComponent<GUIText> ().text = "Left Click: Open Cabinet";
			text.SetActive (true);
		}
	}

	void OnTriggerStay(Collider other){
		if (Input.GetMouseButtonDown (0)
			&& !lv2_logic_control.openCabinet
			&& !clicked)
		{
			cabinet.GetComponent<Animator> ().SetBool ("open", true);
			text.GetComponent<GUIText> ().text = "";
			clicked = true;
			StartCoroutine (waitToTake ());
		}
	}

	void OnTriggerExit(Collider other)
	{
		text.SetActive (false);
	}

	IEnumerator waitToTake()
	{
		yield return new WaitForSeconds (2.0f);
		text.GetComponent<GUIText> ().text = "A tiny tank of fuel\nLeft Click: Take";
		lv2_logic_control.openCabinet = true;
	}
}
