using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullingActive : MonoBehaviour {

	Rigidbody rigid;
	private Vector3 clickPosition;
	private const float jumpPower = 10;
	private bool canJump = false;

	// Start is called before the first frame update
	void Start() {
		rigid = gameObject.GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update() {
		if (Input.GetMouseButtonDown(0)) {
			clickPosition = Input.mousePosition;
		}
		if (Input.GetMouseButtonUp(0) && canJump) {
			Vector3 dist = clickPosition - Input.mousePosition;
			if (dist.magnitude != 0) {
				rigid.velocity = dist.normalized * jumpPower;
			}
		}
	}

	private void OnCollisionStay(Collision collision) {
		ContactPoint[] contactPoint = collision.contacts;
		Vector3 normal = contactPoint[0].normal;
		float dot = Vector3.Dot(normal, Vector3.up);
		if (dot >= Mathf.Cos(45)) {
			canJump = true;
		}
	}

	private void OnCollisionExit(Collision collision) {
		canJump = false;
	}
}
