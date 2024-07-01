using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class MoveFloorScript : MonoBehaviour {

	private Rigidbody floorRigidbody;

	[SerializeField]
	private Vector2 moveDirection;
	[SerializeField]
	private float moveTime;
	[SerializeField]
	private float moveDistance;
	[SerializeField]
	private float stopTime;

	private float timeSum = 0;

	// Start is called before the first frame update
	void Start() {
		floorRigidbody = GetComponent<Rigidbody>();
		moveDirection.Normalize();
	}

	// Update is called once per frame
	void Update() {
	}

	void FixedUpdate() {
		float nowTime = timeSum % ((stopTime + moveTime) * 2);
		bool isBack = nowTime > (stopTime + moveTime);
		Vector3 nowPosition = new();
		Vector3 nextPosition = new();
		if (!isBack) {
			nowPosition = Vector3.Lerp(Vector3.zero, moveDirection * moveDistance, Easing.InOutSine(Mathf.Clamp(nowTime / moveTime, 0, 1)));
			nextPosition = Vector3.Lerp(Vector3.zero, moveDirection * moveDistance, Easing.InOutSine(Mathf.Clamp((nowTime + Time.deltaTime) / moveTime, 0, 1)));
		}
		else {
			nowPosition = Vector3.Lerp(moveDirection * moveDistance, Vector3.zero, Easing.InOutSine(Mathf.Clamp((nowTime - (stopTime + moveTime)) / moveTime, 0, 1)));
			nextPosition = Vector3.Lerp(moveDirection * moveDistance, Vector3.zero, Easing.InOutSine(Mathf.Clamp((nowTime - (stopTime + moveTime) + Time.deltaTime) / moveTime, 0, 1)));
		}
		floorRigidbody.MovePosition(nextPosition - nowPosition + floorRigidbody.position);
		timeSum += Time.deltaTime;
	}
}
