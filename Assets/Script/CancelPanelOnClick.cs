using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelPanelOnClick : MonoBehaviour {
	public GameObject panel;

	// Use this for initialization
	public void CancelExitPanel()
	{
		FirstPersonController.menu_opened = false;
		Screen.lockCursor = true;
		panel.SetActive (false);
	}
}
