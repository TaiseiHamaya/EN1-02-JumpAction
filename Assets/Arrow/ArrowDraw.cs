using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowDraw : MonoBehaviour {

	[SerializeField]
	private Image arrowImage;
	private Vector3 clickPosition;

	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {
		if (Input.GetMouseButtonDown(0)) {
			clickPosition = Input.mousePosition;
			arrowImage.gameObject.SetActive(true);
		}
		if (Input.GetMouseButton(0)) {
			Vector3 dist = clickPosition - Input.mousePosition;
			float size = dist.magnitude;
			float angle = Mathf.Atan2(dist.y, dist.x);
			arrowImage.rectTransform.rotation = Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg);
			arrowImage.rectTransform.position = clickPosition;
			arrowImage.rectTransform.sizeDelta = new Vector2(size, size);
		}
		if (Input.GetMouseButtonUp(0)) {
			arrowImage.gameObject.SetActive(false);
		}
	}
}
