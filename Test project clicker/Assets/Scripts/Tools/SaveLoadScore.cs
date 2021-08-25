using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Linq;

public class SaveLoadScore:MonoBehaviour
{
    private int _score;
    private string _filePath;

    private void OnEnable()
    {
        _filePath = Application.persistentDataPath + "/Score.data";
    }

    private void Start()
    {
        _filePath = Application.persistentDataPath + "/Score.data";
    }

    public void Save(ScoreData scoreData)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        
        Save save = new Save();

        if (File.Exists(_filePath))
        {
            save = Load();

            save.AddChangeScoreData(scoreData);

        }
        else
        {
            save.AddChangeScoreData(scoreData);

        }

        FileStream fileStream = new FileStream(_filePath, FileMode.OpenOrCreate);
        binaryFormatter.Serialize(fileStream, save);

        fileStream.Close();

    }

    public Save Load()
    {
        if (!File.Exists(_filePath))
            return new Save();

        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream = new FileStream(_filePath, FileMode.Open);

        Save save = (Save) binaryFormatter.Deserialize(fileStream);

        fileStream.Close();

        return save;
    }
}

[System.Serializable]
public class Save
{
    public List<ScoreData> ScoreDatas = new List<ScoreData>();

    public bool AddChangeScoreData(ScoreData scoreData)
    {
        if (scoreData == null)
            return false;

        var matches = ScoreDatas.Where(score => score.PlayerName == scoreData.PlayerName).ToList();

        foreach(ScoreData save in matches)
        {
            if (save.Score < scoreData.Score)
            {
                save.Score = scoreData.Score;
                return true;
            }
            else
            {
                return false;
            }
                
        }

        ScoreDatas.Add(scoreData);

        return true;
    }

}

[System.Serializable]
public class ScoreData
{
    public string PlayerName;
    public int Score;

    public ScoreData(string playerName, int score)
    {
        PlayerName = playerName;
        Score = score;
    }
}