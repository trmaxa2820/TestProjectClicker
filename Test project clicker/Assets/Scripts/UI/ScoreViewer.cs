using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreViewer : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;

    public void SetScoreText(ScoreData scoreData)
    {
        _scoreText.text = scoreData.PlayerName + ": " + scoreData.Score;
    }
}

