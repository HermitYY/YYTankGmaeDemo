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
        Debug.Log("��ʼ��Ϸ");
        SceneManager.LoadScene("MainGameScene");
    }

    public void OnSettingButton()
    {
        Debug.Log("��Ϸ����");
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }
}
