using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crow_rock : MonoBehaviour {
	public GameObject rock, newRock, text;
	public AudioSource se;
	public Transform rockSwpanSpot;

	// Use this for initialization
	void Start () {
		text.SetActive (false);
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			if (!logic_control.crowed_rock)
			{
				if (lv1_item_control.item[2])
					text.GetComponent<GUIText> ().text = "Right Click: Crow";
				else
					text.GetComponent<GUIText> ().text = "A rock cracked into the gap\nNeed something to get it out";
				text.SetActive (true);
			}
		}
	}

	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player")
		{
			if (!logic_control.crowed_rock)
			{
				text.GetComponent<GUIText> ().text = "A rock cracked into the gap\nNeed something to get it out";
				if (lv1_item_control.item [2] && lv1_item_control.num == 2)
				{
					text.GetComponent<GUIText> ().text = "Right Click: Crow";

					if (Input.GetMouseButtonDown (1))
					{
						Destroy (rock);
						Instantiate (newRock, rockSwpanSpot.position, rockSwpanSpot.rotation);
						se.Play ();
						logic_control.crowed_rock = true;
						text.SetActive (false);
					}
				}
			}
		}
	}

	void OnTriggerExit()
	{
		text.SetActive (false);
	}
}
