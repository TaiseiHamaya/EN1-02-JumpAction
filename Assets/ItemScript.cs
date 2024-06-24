using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour {

	private Animator animator;
	private AudioSource audioSource;

	void DestroySelf() {
		Destroy(gameObject);
	}

	// Start is called before the first frame update
	void Start() {
		animator = GetComponent<Animator>();
		audioSource = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update() {

	}

	private void OnTriggerEnter(Collider other) {
		animator.SetTrigger("Get");
		audioSource.Play();
	}
}
