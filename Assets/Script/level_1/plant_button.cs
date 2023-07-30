using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plant_button : MonoBehaviour {
	public GameObject oldShelf;
	public GameObject newShelf;
	public AudioSource se;
	public GameObject key;
	public Transform shelfSpwanSpot;
	public GameObject text;
	//public static bool button_pressed;

	void Start()
	{
		//button_pressed = false;
		key.SetActive (false);
		text.SetActive (false);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player" && !logic_control.button_pressed) {
			text.GetComponent<GUIText> ().text = "A weird button\nWhat is a button on a plant use for\nLeft Click: Press Button";
			text.SetActive (true);
		}
	}

	void OnTriggerStay(Collider other)
	{
		//Debug.Log ("player in");

		if (other.tag == "Player" && Input.GetMouseButtonDown (0) && !logic_control.button_pressed)
		{
			DestroyObject (oldShelf);
			Instantiate (newShelf, shelfSpwanSpot.position, shelfSpwanSpot.rotation);
			se.Play();
			key.SetActive (true);
			text.SetActive (false);
			logic_control.button_pressed = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		text.SetActive (false);
	}
}