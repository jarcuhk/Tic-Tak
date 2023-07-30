using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fakeEnding : MonoBehaviour {
	public GameObject text, camera, button;

	// Use this for initialization
	void Start () {
		StartCoroutine (show ());
	}

	IEnumerator show() {
		yield return new WaitForSeconds (1.0f);
		camera.GetComponent<Animator> ().SetBool ("play", true);

		yield return new WaitForSeconds (12.0f);
		text.SetActive (true);

		yield return new WaitForSeconds (2.0f);
		button.SetActive (true);
	}
}
