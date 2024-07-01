using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ItemScript : MonoBehaviour {

	private Animator animator;
	private AudioSource audioSource;

	[SerializeField]
	private GameObject scorePrefab;

	private ScoreScript scoreScript;

	void DestroySelf() {
		Destroy(gameObject);
		scoreScript.AddScore();
	}

	// Start is called before the first frame update
	void Start() {
		scoreScript = scorePrefab.GetComponent<ScoreScript>();
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
