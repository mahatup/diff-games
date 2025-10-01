using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneName
{
    Ball,
    Sprint
}
[Serializable]
public class SceneId
{
    public SceneName SceneName;
    public int Id;
}
public class LoaderService : MonoBehaviour
{
    [SerializeField] private GameMenuView _gameMenuView;
    [SerializeField] private SceneId[] _sceneIds;
    private void OnEnable()
    {
        _gameMenuView.SelectGameButtonClicked += OnSelectGameButtonClicked;
        _gameMenuView.ExitButtonClicked += OnExitButtonClicked;

        _gameMenuView.SelectBallGameButtonClicked += OnSelectBallGameButtonClicked;
        _gameMenuView.SelectSprintGameButtonClicked += OnSelectSprintGameButtonClicked;
        _gameMenuView.ExitToMenuButtonClicked += OnExitToMenuButtonClicked;
    }

    private void OnDisable()
    {
        _gameMenuView.SelectGameButtonClicked -= OnSelectGameButtonClicked;
        _gameMenuView.ExitButtonClicked -= OnExitButtonClicked;

        _gameMenuView.SelectBallGameButtonClicked -= OnSelectBallGameButtonClicked;
        _gameMenuView.SelectSprintGameButtonClicked -= OnSelectSprintGameButtonClicked;
        _gameMenuView.ExitToMenuButtonClicked -= OnExitToMenuButtonClicked;
    }
    private void OnSelectGameButtonClicked()
    {
        _gameMenuView.SwitchToSelectGameMenu();
    }
    private void OnExitButtonClicked()
    {
        // Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    private void OnSelectSprintGameButtonClicked()
    {
        for (int i = 0; i < _sceneIds.Length; i++)
        {
            if (_sceneIds[i].SceneName == SceneName.Sprint)
            {
                SceneManager.LoadScene(_sceneIds[i].Id);
            }
        }
    }

    private void OnSelectBallGameButtonClicked()
    {
        for (int i = 0; i < _sceneIds.Length; i++)
        {
            if (_sceneIds[i].SceneName == SceneName.Ball)
            {
                SceneManager.LoadScene(_sceneIds[i].Id);
            }
        }
    }
    private void OnExitToMenuButtonClicked()
    {
        _gameMenuView.SwitchToMainMenu();
    }
}
