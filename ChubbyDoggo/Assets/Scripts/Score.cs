using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text scoreText;
    public int carrotValue;

    private int score;

	// Use this for initialization
	void Start () {
        score = 0;
        scoreText.text = "";
    }

    private void OnTriggerEnter2D() {
        score += carrotValue;
        UpdateScore();
    }

    public void setText(){
        UpdateScore();
    }

    void UpdateScore() {
        scoreText.text = "Score:\n" + score;
    }
}
