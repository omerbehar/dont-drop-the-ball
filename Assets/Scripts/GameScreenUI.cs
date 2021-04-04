using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameScreenUI : MonoBehaviour {
    public Text scoreText;
    public BallControl ballControl;
    public CanvasGroup gameOverCanvas;
    public Button startOverButton;
    public Button mainMenuButton;

    private void Start()
    {
        int score = ballControl.score;
        scoreText.text = "Score: " + score;
        gameOverCanvas.alpha = 0;
    }

    private void Awake()
    {
        startOverButton.onClick.AddListener(startOverButtonOnClick);
        mainMenuButton.onClick.AddListener(mainMenuButtonOnClick);
    }

    void startOverButtonOnClick()
    {
        SceneLoader.Load(SceneLoader.Scene.GameScene);
    }

    void mainMenuButtonOnClick()
    {
        SceneLoader.Load(SceneLoader.Scene.StartScreen);
    }

    public void UpdateScoreUI()
    {
        int score = ballControl.score;
        scoreText.text = "Score : " + score;
    }
}
