using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager
{
    private static GameDataManager _instance = new GameDataManager();
    public static GameDataManager Instance => _instance;

    public MusicData musicData;
    public RankTblDataList rankData;

    private GameDataManager()
    {
        Init();
    }

    public void Init()
    {
        InitMusicData();
        InitRankData();
    }

    #region ÒôÁ¿ÉèÖÃ
    private void InitMusicData()
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
    #endregion

    #region ÅÅÐÐ°ñ
    private void InitRankData()
    {
        rankData = PlayerPrefsDataMgr.Instance.LoadData(typeof(RankTblDataList), "rank") as RankTblDataList;
    }

    public void SaveRankData()
    {
        PlayerPrefsDataMgr.Instance.SaveData(rankData, "rank");
    }

    public void AddRankData(RankTblData data)
    {
        rankData.list.Add(data);
        rankData.list.Sort((item1, item2) =>
        {
            if (item1.score != item2.score)
            {
                return item2.score - item1.score;
            }
            return item1.passTime - item2.passTime;
        });
        HashSet<string> seen = new HashSet<string>();
        rankData.list = rankData.list.FindAll(entry =>
        {
            if (seen.Contains(entry.playerName)) return false;
            seen.Add(entry.playerName);
            return true;
        });

        if (rankData.list.Count > 10)
            rankData.list.RemoveRange(10, rankData.list.Count - 10);

        for (int i = 0; i < rankData.list.Count; i++)
        {
            RankTblData tblData = rankData.list[i];
            tblData.rankPos = i + 1;
        }
        SaveRankData();
    }

    #endregion
}
