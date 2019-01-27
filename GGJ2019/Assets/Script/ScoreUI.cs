using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour {

    public Player player;
    public Text scoreText;
    public Text gameOverScoreText;

	
	// Update is called once per frame
	void Update () {
        scoreText.text = "  Score: " + player.score;
        gameOverScoreText.text = "  Score: " + player.score;
    }
}
