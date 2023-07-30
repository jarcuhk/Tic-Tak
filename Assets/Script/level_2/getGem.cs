using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getGem : MonoBehaviour {
	public GameObject gem;
	public GameObject text;

	void OnTriggerEnter(Collider other)
	{
		if (!lv2_logic_control.tookDisc) {
			text.GetComponent<GUIText> ().text = "A beautiful ancient teapot\nbut seems the eye of dragon is falling...\nLeft Click: Take";
			text.SetActive (true);
		}
	}

	void OnTriggerStay(Collider other)
	{
		if(!lv2_logic_control.gotGem)
		{
			text.GetComponent<GUIText> ().text = "A beautiful ancient teapot\nbut seems the eye of dragon is falling...\nLeft Click: Take";
			if (Input.GetMouseButtonDown (0)) {
				DestroyObject (gem);
				text.SetActive (false);
				lv2_logic_control.gotGem = true;
				lv2_item_control.item [1] = true;
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		text.GetComponent<GUIText> ().text = "";
	}
}
