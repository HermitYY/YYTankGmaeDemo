using System.Collections.Generic;
using UnityEngine;

public class RankPanel : BasePanel<RankPanel>
{
    public GameObject RankTblPrefab;
    public GameObject RankTblList;
    void Start()
    {

    }

    void Update()
    {

    }

    public void UpdateRankList(List<RankTblData> listData)
    {
        for (int i = 0; i < RankTblList.transform.childCount; i++)
        {
            Transform child = RankTblList.transform.GetChild(i);
            if (child != null)
            {
                Destroy(child.gameObject);
            }
        }
        // 首行标题
        GameObject titleListTbl = Instantiate(RankTblPrefab, RankTblList.transform);
        titleListTbl.GetComponent<RankTbl>()?.UpdateRankInfo(null);
        if (listData == null) return;
        foreach (var item in listData)
        {
            GameObject newListTbl = Instantiate(RankTblPrefab, RankTblList.transform);
            newListTbl.GetComponent<RankTbl>()?.UpdateRankInfo(item);
        }
    }

    public override void ShowMinePanel()
    {
        base.ShowMinePanel();
        UpdateRankList(GameDataManager.Instance.rankData.list);
        // 测试添加数据
        //RankTblData testData = new RankTblData();
        //testData.playerName = "Test2";
        //testData.passTime = 1000;
        //testData.score = 150;
        //GameDataManager.Instance.AddRankData(testData);
    }
}
