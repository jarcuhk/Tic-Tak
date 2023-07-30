using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorHint : MonoBehaviour {
	public GameObject text;
	
	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			text.GetComponent<GUIText> ().text = "A creepy drawing of a creepy man looking at floor creepily";
			text.SetActive (true);
		}
	}

	void OnTriggerExit(Collider other) {
		text.SetActive (false);
	}
}
