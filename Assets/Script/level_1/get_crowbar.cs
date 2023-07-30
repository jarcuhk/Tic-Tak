using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class get_crowbar : MonoBehaviour {
	public GameObject carpet, newCarpet, crowbar, text;

	// Use this for initialization
	void Start () {
		newCarpet.SetActive (false);
		crowbar.SetActive (false);
		text.SetActive (false);
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			if (!logic_control.carpet_moved)
			{
				text.GetComponent<GUIText> ().text = "Left Click: Lift carpet";
				text.SetActive (true);
			}
			else if (logic_control.carpet_moved && !logic_control.crowbar_token)
			{
				text.GetComponent<GUIText> ().text = "A crowbar\nLeft Click: Take";
				text.SetActive (true);
			}
		}
	}

	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player")
		{
			if (!logic_control.carpet_moved)
			{
				if (Input.GetMouseButtonDown (0))
				{
					Destroy (carpet);
					newCarpet.SetActive (true);
					crowbar.SetActive (true);
					//text.SetActive (false);
					text.GetComponent<GUIText> ().text = "A crowbar\nLeft Click: Take";
					logic_control.carpet_moved = true;
				}
			}
			else if (logic_control.carpet_moved && !logic_control.crowbar_token)
			{
				if (Input.GetMouseButtonDown (0))
				{
					Destroy (crowbar);
					text.SetActive (false);
					logic_control.crowbar_token = true;
					lv1_item_control.item[2] = true;
				}
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		text.SetActive (false);
	}
}