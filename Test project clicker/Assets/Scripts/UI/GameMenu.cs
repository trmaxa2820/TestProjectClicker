using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    [SerializeField] private GameObject _gameMenuPanel;


    private void Start()
    {
        _gameMenuPanel.SetActive(false);
    }

    public void ExitToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void Resume()
    {
        _gameMenuPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OpenMenu()
    {
        Time.timeScale = 0f;
        _gameMenuPanel.SetActive(true);
    }
}
