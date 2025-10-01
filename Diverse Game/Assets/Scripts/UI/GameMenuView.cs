using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenuView : MonoBehaviour
{
    // Вынести в MainMenuView
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private Button _selectGameButton;
    [SerializeField] private Button _exitButton;

    // Вынести в SelectGameMenuView
    [SerializeField] private GameObject _selectGameMenu;
    [SerializeField] private Button _selectBallGameButton;
    [SerializeField] private Button _selectSprintGameButton;
    //TODO: add logic to button
    [SerializeField] private Button _gameButton;
    [SerializeField] private Button _exitToMenuButton;
    // Добавить копиии в MainMenuView
    public event Action SelectGameButtonClicked;
    public event Action ExitButtonClicked;
    //Добавить копиии в SelectGameMenuView
    public event Action SelectBallGameButtonClicked;
    public event Action SelectSprintGameButtonClicked;
    public event Action ExitToMenuButtonClicked;

    public void SwitchToMainMenu()
    {
        _mainMenu.SetActive(true);
        _selectGameMenu.SetActive(false);
    }

    public void SwitchToSelectGameMenu()
    {
        _mainMenu.SetActive(false);
        _selectGameMenu.SetActive(true);
    }

    private void OnEnable()
    {
        _selectGameButton.onClick.AddListener(OnSelectGameButton);
        _exitButton.onClick.AddListener(OnExitButton);
        _selectBallGameButton.onClick.AddListener(OnSelectBallGameButton);
        _selectSprintGameButton.onClick.AddListener(OnSelectSprintGameButton);
        _exitToMenuButton.onClick.AddListener(OnExitToMenuButton);
    }

    private void OnDisable()
    {
        _selectGameButton.onClick.RemoveListener(OnSelectGameButton);
        _exitButton.onClick.RemoveListener(OnExitButton);
        _selectBallGameButton.onClick.RemoveListener(OnSelectBallGameButton);
        _selectSprintGameButton.onClick.RemoveListener(OnSelectSprintGameButton);
        _exitToMenuButton.onClick.RemoveListener(OnExitToMenuButton);
    }
    private void OnSelectBallGameButton()
    {
        SelectBallGameButtonClicked?.Invoke();
    }

    private void OnSelectSprintGameButton()
    {
        SelectSprintGameButtonClicked?.Invoke();
    }
      
    private void OnExitButton()
    {
        ExitButtonClicked?.Invoke();
    }

    private void OnSelectGameButton()
    {
        SelectGameButtonClicked?.Invoke();
    }
    private void OnExitToMenuButton()
    {
        ExitToMenuButtonClicked?.Invoke();
    }

}
