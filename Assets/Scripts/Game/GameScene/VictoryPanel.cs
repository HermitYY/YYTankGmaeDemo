using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryPanel : BasePanel<VictoryPanel>
{
    public TextMeshProUGUI defText;
    public TextMeshProUGUI userText;


    public override void ShowMinePanel()
    {
        base.ShowMinePanel();
        Time.timeScale = 0;
    }

    public override void HideMinePanel()
    {
        base.HideMinePanel();
        Time.timeScale = 1;
    }

    public void OnConfirm()
    {
        RankTblData data = new RankTblData();
        data.passTime = (int)GamePanel.Instance.nowTime;
        data.score = GamePanel.Instance.currentSorce;
        string userName = userText.text == new string("") ? defText.text : userText.text;
        data.playerName = userName;
        GameDataManager.Instance.AddRankData(data);
        HideMinePanel();
        SceneManager.LoadScene("BeginScene");
    }
}
