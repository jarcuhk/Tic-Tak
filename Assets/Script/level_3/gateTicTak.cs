using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gateTicTak : MonoBehaviour {
	public GameObject text, hands, timeText, p1, p2, tp;
	public AudioSource se;

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player" && !lv3_logic_control.tictak) {
			if (!lv3_logic_control.playedPiano) {
				tp.GetComponent<ParticleSystem> ().Play ();

				text.GetComponent<GUIText> ().text = "E: Active";
			}
		}
	}

	void OnTriggerStay(Collider other) {
		if (other.tag == "Player" && !lv3_logic_control.tictak) {
			if (!lv3_logic_control.playedPiano) {
				text.GetComponent<GUIText> ().text = "E: Active";
				if (!tp.GetComponent<ParticleSystem> ().isPlaying) {
					tp.GetComponent<ParticleSystem> ().Play ();
				}
				if (Input.GetKeyDown (KeyCode.E)) {
					Save.tictak = true;
					tp.GetComponent<ParticleSystem> ().Stop ();

					StartCoroutine (tictak ());
				}
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
		hands.SetActive (true);
		hands.GetComponent<Animator> ().Play ("hand");
		yield return new WaitForSeconds (5.5f);

		hands.SetActive (false);
		se.Stop ();
		p1.GetComponent<ParticleSystem> ().Stop ();
		p2.GetComponent<ParticleSystem> ().Stop ();

		lv3_logic_control.tictak = false;
	}

	void OnTriggerExit(Collider other){
		if (!lv3_logic_control.tictak && !lv3_logic_control.playedPiano) {
			text.GetComponent<GUIText> ().text = "";
			tp.GetComponent<ParticleSystem> ().Stop ();
		}
	}
}
