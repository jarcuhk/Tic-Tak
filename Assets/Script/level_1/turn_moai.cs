using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turn_moai : MonoBehaviour {
	public GameObject text, moai;
	public AudioSource se;

	void Start () {
		text.SetActive (false);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			if (!logic_control.moai_turned)
			{
				text.GetComponent<GUIText> ().text = "Left Click: Turn";
				text.SetActive (true);
			}
		}
	}

	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player")
		{
			if (Input.GetMouseButtonDown (0))
			{
				if (logic_control.crowed_rock)
				{
					moai.GetComponent<Animator> ().SetBool ("turn", true);
					se.Play ();
					logic_control.moai_turned = true;
					text.SetActive (false);
				}
				else
					text.GetComponent<GUIText> ().text = "Seems something is blocking\nthe statue to turn";
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		text.SetActive (false);
	}
}
