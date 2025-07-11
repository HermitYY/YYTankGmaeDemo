using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitGamePanel : BasePanel<ExitGamePanel>
{
    public void OnExitGame()
    {
        HideMinePanel();
        SceneManager.LoadScene("BeginScene");
    }

    public void OnContinue()
    {
        HideMinePanel();
    }

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
}
