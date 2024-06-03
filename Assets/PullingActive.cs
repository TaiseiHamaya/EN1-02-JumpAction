using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullingActive : MonoBehaviour {

	Rigidbody rigid;

	// Start is called before the first frame update
	void Start() {
		rigid = gameObject.GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update() {

	}
}
