using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lv3_logic_control : MonoBehaviour {
	public static bool bookOpened, playedPiano, gateOpened, tictak, gg;
	public GameObject keyboard, lights;

	void Start () {
		bookOpened = false; playedPiano = false; gateOpened = false;
		tictak = false; gg = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (playedPiano) {
			keyboard.SetActive (true);
			lights.SetActive (true);
		}
	}
}
