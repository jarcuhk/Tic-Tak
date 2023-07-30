using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tictak_color : MonoBehaviour {
	public GameObject common, active, text, timeText, p1, p2, tp;
	public AudioSource se;

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player" && !lv2_logic_control.tictak) {
			text.GetComponent<GUIText> ().text = "This parchment had something write on it\nbut its too old to see already\nE: Active";
			text.SetActive (true);
		}
	}

	void OnTriggerStay(Collider other) {
		if (other.tag == "Player" && !lv2_logic_control.tictak) {
			text.GetComponent<GUIText> ().text = "This parchment had something write on it\nbut its too old to see already\nE: Active";
			if (!tp.GetComponent<ParticleSystem> ().isPlaying) {
				tp.GetComponent<ParticleSystem> ().Play ();
			}
			if (Input.GetKeyDown (KeyCode.E)) {
				Save.tictak = true;
				tp.GetComponent<ParticleSystem> ().Stop ();

				StartCoroutine (takeTime ());
			}
		}
	}

	void OnTriggerExit(Collider other){
		if (!lv2_logic_control.tictak) {
			text.SetActive (false);
			tp.GetComponent<ParticleSystem> ().Stop ();
		}
	}

	IEnumerator takeTime(){
		lv2_logic_control.tictak = true;
		text.GetComponent<GUIText> ().text = "Something is happening!";
		yield return new WaitForSeconds (3.0f);
		text.GetComponent<GUIText> ().text = "";
		lv2_timer.timeLeft -= 30.0f;
		timeText.GetComponent<GUIText> ().text = "-30s";
		yield return new WaitForSeconds (2.0f);
		timeText.GetComponent<GUIText> ().text = "";

		p1.GetComponent<ParticleSystem> ().Play ();
		p2.GetComponent<ParticleSystem> ().Play ();
		text.GetComponent<GUIText> ().text = "This is...the past?";
		common.SetActive (false);
		active.SetActive (true);
		yield return new WaitForSeconds (10.0f);

		common.SetActive (true);
		active.SetActive (false);
		text.GetComponent<GUIText> ().text = "";
		p1.GetComponent<ParticleSystem> ().Stop ();
		p2.GetComponent<ParticleSystem> ().Stop ();

		lv2_logic_control.tictak = false;
	}
}
