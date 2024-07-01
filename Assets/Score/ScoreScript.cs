using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {
	[SerializeField]
	private Text scoreTextObject;
	int score = 0;

	public void AddScore() {
		score++;
		scoreTextObject.text = score.ToString();
	}

	// Start is called before the first frame update
	void Start() {
		scoreTextObject.text = score.ToString();
	}

	// Update is called once per frame
	void Update() {
	}
}
