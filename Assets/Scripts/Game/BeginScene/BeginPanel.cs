using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginPanel : BasePanel<BeginPanel>
{
    [SerializeField] GameObject settingPanel;

    void Start()
    {
        settingPanel.SetActive(true);
        settingPanel.SetActive(false);
    }

    void Update()
    {
        
    }

    public void OnBeginButton()
    {
        Debug.Log("开始游戏");
        SceneManager.LoadScene("MainGameScene");
    }

    public void OnSettingButton()
    {
        Debug.Log("游戏设置");
        SettingPanel.Instance.ShowMinePanel();
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }
}
