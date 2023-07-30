using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logic_control : MonoBehaviour {
	public static bool button_pressed, first_key_token, door_opened,
		skull_key_token, chain_unlocked, skull_turned,
		carpet_moved, crowbar_token, crowed_rock, moai_turned,
		plugs_showed, eye1_token, eye2_token, nose1_token, nose2_token, mouth_token,frog_turned,
		password_shown, password_correct,
		treasure_shown, treasure_token, gate_opened,
		gg;
	public GameObject eye1, eye2, nose1, nose2, mouth;
	public AudioSource se1, se2, se3, se4, se5;

	public GameObject password, password_light, treasure, leftGate, rightGate;

	// Use this for initialization
	void Start () {
		button_pressed = false; first_key_token = false; door_opened = false;
		skull_key_token = false; chain_unlocked = false; skull_turned = false;
		carpet_moved = false; crowbar_token = false; crowed_rock = false; moai_turned = false;
		plugs_showed = false; eye1_token = false; eye2_token = false;
		nose1_token = false; nose2_token = false; mouth_token = false;
		frog_turned = false;
		password_shown = false; password_correct = false;
		treasure_shown = false; treasure_token = false; gate_opened = false;
		gg = false;

		eye1.SetActive (false); eye2.SetActive (false);
		nose1.SetActive (false); nose2.SetActive (false);
		mouth.SetActive (false);

		password_light.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (skull_turned && moai_turned && !plugs_showed)
			showPlugs ();
		if (skull_turned && moai_turned && frog_turned && !password_shown)
			showPassword ();
		if (password_correct)
			showTreasure ();
		if (treasure_token)
			openGate ();
	}

	void showPlugs()
	{
		eye1.SetActive (true);
		se1.Play ();
		eye2.SetActive (true);
		se2.Play ();
		nose1.SetActive (true);
		se3.Play ();
		nose2.SetActive (true);
		se4.Play ();
		mouth.SetActive (true);
		se5.Play ();

		plugs_showed = true;
	}

	void showPassword()
	{
		//password.GetComponent<Animator> ().SetBool(;
		password.GetComponent<Animator> ().Play("password_up");
		password.transform.position.Set(-0.446f, 2.5f, -6.063721f);

		password_shown = true;
		password_light.SetActive (true);
	}

	void showTreasure()
	{
		password.GetComponent<Animator> ().Play("password_down");
		password.transform.position.Set(-0.446f, 0.25f, -6.063721f);
		
		treasure.GetComponent<Animator>().SetBool("down", true);
		treasure_shown = true;
	}

	void openGate()
	{
		leftGate.GetComponent<Animator> ().SetBool ("open", true);
		rightGate.GetComponent<Animator> ().SetBool ("open", true);
		gate_opened = true;
	}
}
