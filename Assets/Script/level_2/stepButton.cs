using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stepButton : MonoBehaviour {
	public GameObject plane, text;
	public AudioSource se;
	
	void OnTriggerEnter(Collider other)
	{
		if (lv2_logic_control.lighted [0] 
			&& lv2_logic_control.lighted [1] 
			&& lv2_logic_control.lighted [2] 
			&& lv2_logic_control.lighted [3]
			&& !lv2_logic_control.stepped) 
		{
			text.GetComponent<GUIText> ().text = "A step button\nLeft Click: Step";
			text.SetActive (true);
		}
	}

	void OnTriggerStay(Collider other)
	{
		if (lv2_logic_control.lighted [0]
		    && lv2_logic_control.lighted [1]
		    && lv2_logic_control.lighted [2]
		    && lv2_logic_control.lighted [3]
		    && !lv2_logic_control.stepped) 
		{
			if (Input.GetMouseButtonDown (0)) {
				lv2_logic_control.stepped = true;
				plane.GetComponent<Animator> ().SetBool ("open", true);
				se.Play ();
				text.SetActive (false);
			}
		}
	}
}
