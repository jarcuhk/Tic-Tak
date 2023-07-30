using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tictakChess : MonoBehaviour {
	public GameObject common, active, text, timeText, p1, p2, tictakParticle;
	public AudioSource se;

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player" && !lv3_logic_control.tictak) {
			tictakParticle.GetComponent<ParticleSystem> ().Play ();

			text.GetComponent<GUIText> ().text = "A set of Go chess\nE: Active";
		}
	}

	void OnTriggerStay(Collider other) {
		if (other.tag == "Player" && !lv3_logic_control.tictak) {
			text.GetComponent<GUIText> ().text = "A set of Go chess\nE: Active";
			if (!tictakParticle.GetComponent<ParticleSystem> ().isPlaying) {
				tictakParticle.GetComponent<ParticleSystem> ().Play ();
			}
			if (Input.GetKeyDown(KeyCode.E)) {
				Save.tictak = true;
				tictakParticle.GetComponent<ParticleSystem> ().Stop ();

				StartCoroutine (tictak ());
			}
		}
	}

	IEnumerator tictak(){
		lv3_logic_control.tictak = true;
		text.GetComponent<GUIText> ().text = "";
		lv2_timer.timeLeft -= 30.0f;
		timeText.GetComponent<GUIText> ().text = "-30s";
		yield return new WaitForSeconds (2.0f);
		timeText.GetComponent<GUIText> ().text = "";

		se.Play ();
		p1.GetComponent<ParticleSystem> ().Play ();
		p2.GetComponent<ParticleSystem> ().Play ();
		yield return new WaitForSeconds (1.0f);
		common.SetActive (false);
		active.SetActive (true);
		yield return new WaitForSeconds (10.0f);

		common.SetActive (true);
		active.SetActive (false);
		p1.GetComponent<ParticleSystem> ().Stop ();
		p2.GetComponent<ParticleSystem> ().Stop ();

		lv3_logic_control.tictak = false;
	}

	void OnTriggerExit(Collider other){
		if (!lv3_logic_control.tictak) {
			text.GetComponent<GUIText> ().text = "";
			tictakParticle.GetComponent<ParticleSystem> ().Stop ();
		}
	}
}
