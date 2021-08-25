using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class MainMenu : MonoBehaviour
{
    [SerializeField] private AudioSource _mainAudioSource;

    private void Start()
    {
        _mainAudioSource.Play();   
    }

    public void LoadScene(int sceneIndexBuilder)
    {
        SceneManager.LoadScene(sceneIndexBuilder);
    }

    public void Exit()
    {
        Application.Quit();
    }

}
