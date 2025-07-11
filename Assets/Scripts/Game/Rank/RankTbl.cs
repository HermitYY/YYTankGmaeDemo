using TMPro;
using UnityEngine;

public class RankTbl : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI rankPosText;
    [SerializeField] private TextMeshProUGUI playerNameText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI passTimeText;

    public void UpdateRankInfo(RankTblData data)
    {
        if (data == null)
        {
            rankPosText.text = "排名";
            playerNameText.text = "玩家名字";
            scoreText.text = "得分";
            passTimeText.text = "通关花费时间";
            rankPosText.color = new Color32(255, 52, 52, 255);
            playerNameText.color = new Color32(255, 52, 52, 255);
            scoreText.color = new Color32(255, 52, 52, 255);
            passTimeText.color = new Color32(255, 52, 52, 255);
        }
        else
        {
            rankPosText.text = data.rankPos.ToString();
            playerNameText.text = data.playerName;
            scoreText.text = data.score.ToString();
            passTimeText.text = data.passTime.ToString() + "秒";
        }
    }
}
