using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScreenUI : MonoBehaviour {
    public Button startButton;

    private void Awake()
    {
        startButton.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        SceneLoader.Load(SceneLoader.Scene.GameScene);
    }
}
