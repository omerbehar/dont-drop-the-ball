using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lose : MonoBehaviour {
    public CanvasGroup gameOverCanvas;
    public BallControl ballConntrol;
    public Text gameOverText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameOverCanvas.alpha = 1;
        int score = ballConntrol.score;
        gameOverText.text = "Game Over - Score: " + score;

    }
}
