using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turn_skull : MonoBehaviour {
	public GameObject text, warning_text, chain, newChain, skull;
	public Transform chainSpwanSpot;
	public AudioSource chainSE, statueSE;
	bool tried = false;
	//public static bool unlocked, turned;
	//float countdown = 10.0f;

	// Use this for initialization
	void Start () {
		text.SetActive (false); warning_text.SetActive (false);
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			if (!logic_control.skull_turned)
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
			if (!logic_control.chain_unlocked) {
				if (lv1_item_control.item [1] && lv1_item_control.num == 1) {
					text.GetComponent<GUIText> ().text = "Right Clink: Unlock";

					if (Input.GetMouseButtonDown (1)) {
						Destroy (chain);
						Instantiate (newChain, chainSpwanSpot.position, chainSpwanSpot.rotation);
						chainSE.Play ();
						logic_control.chain_unlocked = true;
						text.GetComponent<GUIText> ().text = "Left Click: Turn";
					}
				} else if (lv1_item_control.item [0] && lv1_item_control.num == 0) {
					text.GetComponent<GUIText> ().text = "Right Clink: Unlock";

					if (Input.GetMouseButtonDown (1)) {
						timer.timeLeft -= 30.0f;
						//text.GetComponent<GUIText> ().text = "Oops! Wrong key";

						StartCoroutine (ShowMessage ());
					}
				} else {
					if (!tried) {
						text.GetComponent<GUIText> ().text = "Left Click: Turn";
					}
					if (Input.GetMouseButtonDown (0)) {
						text.GetComponent<GUIText> ().text = "Can't turn\nThe chain is tighted";
						tried = true;
					}
				}
			}
			else if (!logic_control.skull_turned)
			{
				if (Input.GetMouseButtonDown (0))
				{
					skull.GetComponent<Animator> ().SetBool ("turn", true);
					statueSE.Play ();
					logic_control.skull_turned = true;
					text.SetActive (false);
				}
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		text.SetActive (false);
		tried = false;
	}

	IEnumerator ShowMessage()
	{
		warning_text.GetComponent<GUIText> ().text = "YOU";
		warning_text.SetActive (true);
		yield return new WaitForSeconds (1.0f);
		warning_text.GetComponent<GUIText> ().text = "LOST";
		yield return new WaitForSeconds (1.0f);
		warning_text.GetComponent<GUIText> ().text = "30";
		yield return new WaitForSeconds (1.0f);
		//warning_text.GetComponent<GUIText> ().text = "FUCKING";
		//yield return new WaitForSeconds (1.0f);
		warning_text.GetComponent<GUIText> ().text = "SECONDS";
		yield return new WaitForSeconds (1.0f);
		//warning_text.GetComponent<GUIText> ().text = "";
		//yield return new WaitForSeconds (3.0f);
		//warning_text.GetComponent<GUIText> ().text = "FUCKING IDIOT";
		//yield return new WaitForSeconds (1.0f);
		warning_text.SetActive (false);
	}
}
