using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class get_treasure : MonoBehaviour {
	public GameObject clock, holder, text, particle, uiclock;
	public AudioSource se, open_se;
	bool box_opened = false, box_down = false, clicked = false;
	//ParticleSystem part;

	// Use this for initialization
	void Start () {
		text.SetActive (false);
		//particle.SetActive (false);
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player" 
			&& logic_control.treasure_shown 
			&& !logic_control.treasure_token)
		{
			if (!box_opened) 
				text.GetComponent<GUIText> ().text = "Left Click: Open";
			else
				text.GetComponent<GUIText> ().text = "A old pocket watch...\nwith mystery aura\nLeft Click: Take";
			text.SetActive (true);
		}
	}

	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player"
			&& logic_control.treasure_shown
			&& !logic_control.treasure_token)
		{
			if (Input.GetMouseButtonDown (0) && !logic_control.treasure_token)
			{
				if (!box_opened && !clicked)
				{
					holder.GetComponent<Animator> ().SetBool ("open", true);
					open_se.Play ();
					/*
					text.GetComponent<GUIText> ().text = "Left Click: Take the pocket watch";
					//particle.SetActive (true);
					particle.GetComponent<ParticleSystem>().Play();
					box_opened = true;
					*/
					clicked = true;
					StartCoroutine (waitToTake ());
				}
				else if(box_opened && clicked)
				{
					Destroy (clock);
					uiclock.SetActive (true);
					text.SetActive (false);
					se.Play ();
					logic_control.treasure_token = true;
				}
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		text.SetActive (false);
	}

	/*/
	IEnumerator waitToOpen()
	{
		yield return new WaitForSeconds (4.0f);
	}
	*/

	IEnumerator waitToTake()
	{
		yield return new WaitForSeconds (4.0f);
		text.GetComponent<GUIText> ().text = "Left Click: Take the pocket watch";
		particle.GetComponent<ParticleSystem>().Play();
		box_opened = true;
	}
}