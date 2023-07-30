using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trueEnding : MonoBehaviour {
	public GameObject door, camera, button;
	public AudioSource se;

	void Start () {
		StartCoroutine (show ());
	}

	IEnumerator show() {
		yield return new WaitForSeconds (1.0f);
		camera.GetComponent<Animator> ().SetBool ("play", true);
		door.GetComponent<Animator> ().SetBool ("open", true);

		yield return new WaitForSeconds (2.0f);
		se.Play ();

		yield return new WaitForSeconds (5.0f);
		button.SetActive (true);
	}
}
