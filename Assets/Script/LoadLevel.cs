using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour {
	public int level;
	bool cleared;
	public GameObject text;

	public void LoadSceneByIndex(int index)
	{
		if (level == 1) {
			cleared = true;
		} else if (level == 2) {
			cleared = Save.clearLV1;
		} else if (level == 3) {
			cleared = Save.clearLV2;
		}

		if (cleared) {
			SceneManager.LoadScene (index);
		} else {
			if (level == 2) {
				text.GetComponent<GUIText> ().text = "Need to clear Level I";
			} else if (level == 3) {
				text.GetComponent<GUIText> ().text  = "Need to clear Level II";
			}
		}
	}
}
