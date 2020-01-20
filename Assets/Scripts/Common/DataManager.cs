using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    private const string KEY_DATA="GameDataManager";

    [SerializeField]
    private GameData _gameData =new GameData();

    public GameData GameData
    {
        get { return _gameData; }
        set { _gameData = value; }
    }

    protected override void Awake()
    {
        base.Awake();
        InitData();
    }

    public void InitData()
    {
        _gameData = JsonUtility.FromJson<GameData>(PlayerPrefs.GetString(KEY_DATA));
        if (_gameData == null)
        {
            _gameData = new GameData();
            SaveData();
        }
    }

    [ContextMenu("SaveData")]
    public void SaveData()
    {
        PlayerPrefs.SetString(KEY_DATA, JsonUtility.ToJson(_gameData));
    }

}

[System.Serializable]
public class GameData
{
    [Header("Main Data")]
    public int level;
    public int coin;
    public int highScore;
    public List<bool> skinPlayer;
    public int skinSelect;
    public int totalShuriken;

    public GameData()
    {
        level = 0;
        coin = 0;
        highScore = 0;
        skinPlayer = new List<bool>();
        skinSelect = 0;
        totalShuriken = 0;
    }
}
