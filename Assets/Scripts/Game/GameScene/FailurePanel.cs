using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailurePanel : BasePanel<FailurePanel>
{
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

    public void OnConfirm() {
        this.HideMinePanel() ;
        SceneManager.LoadScene("BeginScene");
    }

    public void OnRetry() {
        this.HideMinePanel();
        SceneManager.LoadScene("MainGameScene");
    }
}
