using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class open_door : MonoBehaviour {
	public GameObject left_door, right_door, text;
	public int time;
	private Animator left_anim, right_anim;
	public AudioSource se;
	//public static bool opened;

	// Use this for initialization
	void Start () {
		text.SetActive (false);
		left_anim = left_door.GetComponent<Animator>();
		right_anim = right_door.GetComponent<Animator>();
	}
	
	void OnTriggerEnter(Collider other)
	{
		/*if (!logic_control.door_opened && !lv1_item_control.item[0])
		{
			text.GetComponent<GUIText> ().text = "The door is locked\nNeeds a key to unlock";
			text.SetActive (true);
		}
		else if (!logic_control.door_opened && lv1_item_control.item[0])
		{
			text.GetComponent<GUIText> ().text = "Right Click: Use item";
			text.SetActive (true);
		}*/

		if (!logic_control.door_opened) {
			if (lv1_item_control.item [0] && lv1_item_control.num == 0) {
				text.GetComponent<GUIText> ().text = "Right Click: Unlock";
			} else {
				text.GetComponent<GUIText> ().text = "The door is locked\nNeeds a key to unlock";
			}

			text.SetActive (true);
		}
	}

	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player" 
			&& !logic_control.door_opened)
		{
			if (lv1_item_control.num == 0 && lv1_item_control.item[0]) {
				text.GetComponent<GUIText> ().text = "Right Click: Use item";
				if (Input.GetMouseButtonDown (1))
				{
					text.SetActive (false);
					left_anim.SetBool ("open", true);
					right_anim.SetBool ("open", true);
					se.Play ();
					logic_control.door_opened = true;

					timer.timeLeft = (float)time;
				}
			}
			else
				text.GetComponent<GUIText> ().text = "The door is locked\nNeeds a key to unlock";
		}
	}

	void OnTriggerExit(Collider other)
	{
		text.SetActive (false);
	}
}
