using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ending : MonoBehaviour {

	public void load(){
		Save.clearLV1 = false;
		Save.clearLV2 = false;
		Save.clearLV3 = false;
		if (Save.tictak) {
			Save.tictak = false;
			SceneManager.LoadScene (11);
		} else {
			SceneManager.LoadScene (12);
		}
	}
}
