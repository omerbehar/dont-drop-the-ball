using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;

public class LoginWindowView : MonoBehaviour
{
    public bool ClearPlayerPrefs;
    public TMPro.TMP_InputField Username;
    public TMPro.TMP_InputField Password;
    public TMPro.TMP_InputField ConfirmPassword;

    public Button LoginButton;
    public Button PlayAsGuestButton;
    public Button PlayButton;

    public GetPlayerCombinedInfoRequestParams InfoRequestParams;

    public GameObject loginWindow;

    // Start is called before the first frame update
    void Start()
    {
        if (ClearPlayerPrefs) PlayerPrefs.DeleteAll();
        if (PlayerPrefs.HasKey("PASSWORD"))
        {
            LoginWithPlayFabRequest request = new LoginWithPlayFabRequest
            {
                Username = PlayerPrefs.GetString("USERNAME"),
                Password = PlayerPrefs.GetString("PASSWORD")
            };
            PlayFabClientAPI.LoginWithPlayFab(request, OnLoginSuccess, OnLoginFailure);
        }
        PlayButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Awake()
    {
        PlayButton.onClick.AddListener(StartGame);
        LoginButton.onClick.AddListener(Login);
    }

    void Login()
    {
        
        LoginWithPlayFabRequest request = new LoginWithPlayFabRequest
        {
            Username = Username.text,
            Password = Password.text
        };
        PlayFabClientAPI.LoginWithPlayFab(request, OnLoginSuccess, OnLoginFailure);
    }
    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Congratulations, you are logged in!");
        PlayerPrefs.SetString("PASSWORD", Password.text);
        PlayerPrefs.SetString("USERNAME", Username.text);
        loginWindow.SetActive(false);
        PlayButton.gameObject.SetActive(true);
    }

    private void OnLoginFailure(PlayFabError error)
    {
        RegisterPlayFabUserRequest regRequest = new RegisterPlayFabUserRequest
        {
            Username = Username.text,
            Password = Password.text,
            RequireBothUsernameAndEmail = false,
            Email = null
        };
        PlayFabClientAPI.RegisterPlayFabUser(regRequest, OnRegisterSuccess, OnRegisterFailure);
        Debug.LogWarning("Something went wrong with your first API call.  :(");
        Debug.LogError("Here's some debug information:");
        Debug.LogError(error.GenerateErrorReport());
    }

    private void OnRegisterFailure(PlayFabError error)
    {
        Debug.LogWarning("Something went wrong with your registration attempt  :(");
        Debug.LogError("Here's some debug information:");
        Debug.LogError(error.GenerateErrorReport());
    }

    private void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        Debug.Log("Congratulations, you are now registered!");
        PlayerPrefs.SetString("PASSWORD", Password.text);
        PlayerPrefs.SetString("USERNAME", Username.text);
        loginWindow.SetActive(false);
        PlayButton.gameObject.SetActive(true);
    }

    void StartGame()
    {
        SceneLoader.Load(SceneLoader.Scene.GameScene);
    }
}

