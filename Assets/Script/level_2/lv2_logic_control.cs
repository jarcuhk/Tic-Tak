using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lv2_logic_control : MonoBehaviour {
	public static bool tookDisc, playDisc,
						gotGem, openCabinet, gotFuel, gotLighter,
						safeOpen, gotKey, tictak,
						stepped, openedGate,
						gg;
	public static bool[] lighted = new bool[4];
	public GameObject button;
	public AudioSource buttonSE;

	void Start () {
		tookDisc = false; playDisc = false;
		gotGem = false; openCabinet = false; gotFuel = false; gotLighter = false;
		safeOpen = false; gotKey = false; tictak = false;
		stepped = false; openedGate = false;
		gg = false;

		for (int i = 0; i < 4; i++) {
			lighted [i] = false;
		}
	}

	void Update () {
		if (lighted [0] && lighted [1] && lighted [2] && lighted [3]
			&& !button.activeSelf) {
			button.SetActive (true);
			buttonSE.Play ();
		}
	}
}
