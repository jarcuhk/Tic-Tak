using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bye : MonoBehaviour {
	public GameObject title, sign, manage, design, programming, model, special ,drawing, az, thanks;
	public GameObject johnUp, johnDown, wiiUp, wiiDown, kahoUp, kahoDown, yiuUp, yiuDown;
	public AudioSource se;


	// Use this for initialization
	void Start () {
		StartCoroutine (show ());
		se.Play ();
	}
	
	IEnumerator show() {
		yield return new WaitForSeconds (5.0f);

		sign.SetActive (true);

		manage.SetActive (true);
		johnUp.SetActive (true);
		kahoDown.SetActive (true);

		yield return new WaitForSeconds (5.0f);

		sign.SetActive (false);
		manage.SetActive (false);
		johnUp.SetActive (false);
		kahoDown.SetActive (false);

		yield return new WaitForSeconds (1.0f);

		sign.SetActive (true);
		design.SetActive (true);
		yiuUp.SetActive (true);
		wiiDown.SetActive (true);

		yield return new WaitForSeconds (5.0f);

		sign.SetActive (false);
		design.SetActive (false);
		yiuUp.SetActive (false);
		wiiDown.SetActive (false);

		yield return new WaitForSeconds (1.0f);

		sign.SetActive (true);
		model.SetActive (true);
		kahoUp.SetActive (true);
		yiuDown.SetActive (true);

		yield return new WaitForSeconds (5.0f);

		sign.SetActive (false);
		model.SetActive (false);
		kahoUp.SetActive (false);
		yiuDown.SetActive (false);

		yield return new WaitForSeconds (1.0f);

		sign.SetActive (true);
		programming.SetActive (true);
		johnUp.SetActive (true);
		wiiDown.SetActive (true);

		yield return new WaitForSeconds (5.0f);

		sign.SetActive (false);
		programming.SetActive (false);
		johnUp.SetActive (false);
		wiiDown.SetActive (false);

		yield return new WaitForSeconds (1.0f);

		sign.SetActive (true);
		special.SetActive (true);
		drawing.SetActive (true);
		az.SetActive (true);

		yield return new WaitForSeconds (5.0f);

		sign.SetActive (false);
		special.SetActive (false);
		drawing.SetActive (false);
		az.SetActive (false);

		yield return new WaitForSeconds (1.0f);

		sign.SetActive (false);
		title.SetActive (false);
		thanks.SetActive (true);

		yield return new WaitForSeconds (6.0f);

		SceneManager.LoadScene (0);
	}
}
