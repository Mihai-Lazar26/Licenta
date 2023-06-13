using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool _pauseMenuToggle = false;
    public bool IsPaused {get => _pauseMenuToggle;}
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private LoadedData _loadedData;

    private GameObject _player;

    [SerializeField] private GameObject _optionsMenu;

    private void Start() {
        _player = GameObject.FindWithTag("Player");
        Time.timeScale = 1;
        _pauseMenuToggle = false;
        _pauseMenu.SetActive(false);
        _optionsMenu.SetActive(false);
    }

    public void Pause(InputAction.CallbackContext context) {
        if (context.performed){
            if (_optionsMenu.activeSelf) {
                _optionsMenu.SetActive(false);
                _pauseMenu.SetActive(true);
                _pauseMenuToggle = true;
                return;
            }
            if (_pauseMenuToggle) {
                Time.timeScale = 1;
            }
            else {
                Time.timeScale = 0;
            }
            _pauseMenuToggle = !_pauseMenuToggle;
            _pauseMenu.SetActive(_pauseMenuToggle);
            
        }
    }

    public void ContinueButton() {
        Time.timeScale = 1;
        _pauseMenuToggle = false;
        _optionsMenu.SetActive(false);
        _pauseMenu.SetActive(false);
    }

    public void OptionsButton() {
        _optionsMenu.SetActive(true);
        _pauseMenu.SetActive(false);
    }

    public void OptionsMenuBack() {
        _optionsMenu.SetActive(false);
        _pauseMenu.SetActive(true);
    }

    public void MainMenuButton() {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
