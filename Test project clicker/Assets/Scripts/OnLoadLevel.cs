using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class OnLoadLevel : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private Player _player;
    [SerializeField] private AudioSource _gameMusicAudioSource;
   
    private void Awake()
    {
        Time.timeScale = 0f;
        _inputField.onEndEdit.AddListener(SetPlayerName);
        
    }

    public void OpenKeyboard()
    {
        TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default, false, false, true);
    }

    public void SetPlayerName(string playerName)
    {
        Time.timeScale = 1f;
        _player.SetPlayerName(playerName);
        _inputField.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        _inputField.onEndEdit.RemoveListener(SetPlayerName);
    }

    private void Start()
    {
        _gameMusicAudioSource.Play();
    }
}
