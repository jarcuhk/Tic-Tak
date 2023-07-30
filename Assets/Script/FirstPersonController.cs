using UnityEngine;
using System.Collections;

[RequireComponent (typeof(CharacterController))]
public class FirstPersonController : MonoBehaviour {
	
	public float movementSpeed = 5.0f;
	public float mouseSensitivity = 5.0f;
	public float jumpSpeed = 20.0f;
	
	float verticalRotation = 0;
	public float upDownRange = 60.0f;
	
	float verticalVelocity = 0;

	public GameObject exitMenu;
	public static bool menu_opened = false;
	
	CharacterController characterController;
	
	// Use this for initialization
	void Start () {
		Screen.lockCursor = true;
		characterController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!menu_opened) {
			float rotLeftRight = Input.GetAxis ("Mouse X") * mouseSensitivity;
			transform.Rotate (0, rotLeftRight, 0);

			verticalRotation -= Input.GetAxis ("Mouse Y") * mouseSensitivity;
			verticalRotation = Mathf.Clamp (verticalRotation, -upDownRange, upDownRange);
			Camera.main.transform.localRotation = Quaternion.Euler (verticalRotation, 0, 0);
		}

			// Movement
		
			float forwardSpeed = Input.GetAxis ("Vertical") * movementSpeed;
			float sideSpeed = Input.GetAxis ("Horizontal") * movementSpeed;
		
			verticalVelocity += Physics.gravity.y * Time.deltaTime;
		
			if (characterController.isGrounded && Input.GetButton ("Jump")) {
				verticalVelocity = jumpSpeed;
			}
		
			Vector3 speed = new Vector3 (sideSpeed, verticalVelocity, forwardSpeed);
		
			speed = transform.rotation * speed;

			characterController.Move (speed * Time.deltaTime);

		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (!menu_opened) {
				menu_opened = true;
				exitMenu.SetActive (true);
				Screen.lockCursor = false;
			} else {
				menu_opened = false;
				exitMenu.SetActive (false);
				Screen.lockCursor = true;
			}
		}
	}
}
