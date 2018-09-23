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
        UpdateScore();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Chocolate") {
            score -= (carrotValue * 2);
        } else if (collision.gameObject.tag == "Carrot") {
            score += carrotValue;
        }
        UpdateScore();
    }

    void UpdateScore() {
        scoreText.text = "Score:\n" + score;
    }
}
