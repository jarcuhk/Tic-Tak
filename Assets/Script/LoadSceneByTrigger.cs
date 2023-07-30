using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneByTrigger : MonoBehaviour {

	public int level;

	// Use this for initialization
	public void OnTriggerEnter(Collider other)
	{
		switch (level) {
			case 1:
				if (other.tag == "Player" && logic_control.gate_opened) {
					Screen.lockCursor = false;
					Save.clearLV1 = true;
					SceneManager.LoadScene (3);
				}
				break;
		case 2:
			if (other.tag == "Player" && lv2_logic_control.openedGate) {
				Screen.lockCursor = false;
				Save.clearLV2 = true;
				SceneManager.LoadScene (6);
			}
			break;
		case 3:
			if (other.tag == "Player" && lv3_logic_control.gateOpened) {
				Screen.lockCursor = false;
				Save.clearLV3 = true;
				SceneManager.LoadScene (9);
			}
			break;

		}
	}
}
