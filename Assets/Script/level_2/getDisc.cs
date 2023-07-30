using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getDisc : MonoBehaviour {
	public GameObject disc;
	public GameObject text;

	void Start () {
		text.SetActive (false);
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (!lv2_logic_control.tookDisc) {
			text.GetComponent<GUIText> ().text = "A gramophone record\nLeft Click: Take";
			text.SetActive (true);
		}
	}

	void OnTriggerStay(Collider other)
	{
		if (Input.GetMouseButtonDown (0)
			&& !lv2_logic_control.tookDisc)
		{
			DestroyObject (disc);
			text.SetActive (false);
			lv2_logic_control.tookDisc = true;
			lv2_item_control.item[0] = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		text.SetActive (false);
	}
}
