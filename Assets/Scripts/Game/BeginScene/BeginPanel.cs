using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginPanel : BasePanel<BeginPanel>
{
    void Start()
    {
        
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
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }
}
