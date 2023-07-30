using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getFuel : MonoBehaviour {
	public GameObject fuel;
	public GameObject text;

	void Start () {
		text.SetActive (false);
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (!lv2_logic_control.gotFuel && lv2_logic_control.openCabinet) {
			text.GetComponent<GUIText> ().text = "A tiny tank of fuel\nLeft Click: Take";
			text.SetActive (true);
		}
	}

	void OnTriggerStay(Collider other)
	{
		if (Input.GetMouseButtonDown (0)
			&& lv2_logic_control.openCabinet
			&& !lv2_logic_control.gotFuel)
		{
			DestroyObject (fuel);
			text.SetActive (false);
			lv2_item_control.item[2] = true;
			lv2_logic_control.gotFuel = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		text.SetActive (false);
	}
}
