using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SaveLoadScore))]
public class ScoreboardMenu : MonoBehaviour
{
    [SerializeField] private GameObject _content;
    [SerializeField] private SaveLoadScore _saveLoadScore;
    [SerializeField] private ScoreViewer _template;

    private List<ScoreViewer> _scoreViewers;

    private void Awake()
    {
        _saveLoadScore = GetComponent<SaveLoadScore>();
        _scoreViewers = new List<ScoreViewer>();
    }

    public void LoadScore()
    {
        enabled = true;
        Save save = _saveLoadScore.Load();

        foreach(ScoreData scoreData in save.ScoreDatas)
        {
            ScoreViewer scoreViewer = Instantiate(_template, _content.transform);
            scoreViewer.SetScoreText(scoreData);
            _scoreViewers.Add(scoreViewer);
        }
    }

    public void Exit()
    {
        foreach(ScoreViewer scoreViewer in _scoreViewers)
        {
            Destroy(scoreViewer.gameObject);
        }
    }
}
