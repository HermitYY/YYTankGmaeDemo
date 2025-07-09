using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : BasePanel<GamePanel>
{
    public GameObject exitGamePanel;

    public TextMeshProUGUI TimeText;
    [HideInInspector]
    public float nowTime;

    public TextMeshProUGUI SorceText;
    [HideInInspector]
    public int currentSorce;

    void Start()
    {
        exitGamePanel.SetActive(true);
        exitGamePanel.SetActive(false);
    }

    void Update()
    {
        nowTime += Time.deltaTime;
        UpdateTime();
    }

    public void OnSettingButton() {
        SettingPanel.Instance.ShowMinePanel();
    }

    public void OnExitButton() {
        ExitGamePanel.Instance.ShowMinePanel();
    }

    private void UpdateTime()
    {
        TimeText.text = nowTime.ToString("0.0") + " √Î";
    }
}
