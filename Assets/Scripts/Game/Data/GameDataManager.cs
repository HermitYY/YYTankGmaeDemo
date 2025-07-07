using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager
{
    private static GameDataManager _instance = new GameDataManager();
    public static GameDataManager Instance => _instance;

    public MusicData musicData;

    private GameDataManager()
    {
        Init();
    }

    public void Init()
    {
        musicData = PlayerPrefsDataMgr.Instance.LoadData(typeof(MusicData), "music") as MusicData;
        if (!musicData.isDataInit)
        {
            musicData.BGMIsOpen = true;
            musicData.BGMVolume = 1f;
            musicData.EffectIsOpen = true;
            musicData.EffectVolume = 1f;
            musicData.isDataInit = true;
            SaveMusicData();
        }
    }

    public void SaveMusicData()
    {
        PlayerPrefsDataMgr.Instance.SaveData(musicData, "music");
    }
}
