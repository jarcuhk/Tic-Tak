using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour {
	public static bool clearLV1 = false, clearLV2 = false, clearLV3 = false, tictak = false;

	void Start () {
		DontDestroyOnLoad (this);
		Debug.Log ("LV1: " + clearLV1 + ", LV2: " + clearLV2 + ", LV3: " + clearLV3);
	}
}
