using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SaveLoadScore))]
public class PlayerScore : MonoBehaviour
{
    public event UnityAction<int> OnScoreChanged;

    [SerializeField] private Player _player;
    [SerializeField] private SaveLoadScore _saveLoadScore;

    public int Score { get; private set; }
    public static PlayerScore Instance { get; private set; }
    
    private void Awake()
    {
        if(PlayerScore.Instance == null)
        {
            Instance = this;
            _saveLoadScore = GetComponent<SaveLoadScore>();
            return;
        }

        Destroy(this.gameObject);
    }

    public void RaiseScore(int score)
    {
        Score += score;
        OnScoreChanged?.Invoke(Score);
        _saveLoadScore.Save(new ScoreData(_player.Name, Score));
    }
}
