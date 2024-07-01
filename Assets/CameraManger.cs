using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class CameraManger : MonoBehaviour {

	private Transform cameraTransform;
	[SerializeField]
	private Transform playerTransform;

	// Start is called before the first frame update
	void Start() {
		cameraTransform = GetComponent<Transform>();
	}

	// Update is called once per frame
	void Update() {
		Vector3 newPos = new Vector3(0.0f, 0.0f, -10.0f);
		newPos.y = Mathf.Clamp(Mathf.Lerp(cameraTransform.position.y, playerTransform.position.y, 0.05f), 5.0f, 64.5f);
		cameraTransform.position = newPos;
	}
}
