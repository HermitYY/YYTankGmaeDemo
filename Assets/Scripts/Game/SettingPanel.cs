using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanel : BasePanel<SettingPanel>
{
    [SerializeField] private GameObject BGMCloseButton;
    [SerializeField] private GameObject BGMOpenButton;
    [SerializeField] private Slider BGMSlider;
    [SerializeField] private GameObject EffectCloseButton;
    [SerializeField] private GameObject EffectOpenButton;
    [SerializeField] private Slider EffectSlider;

    private MusicData musicData;
    void Start()
    {
        UpdataPanelInfo();
    }

    public void OnBGMClose() {
        BGMCloseButton.SetActive(false);
        BGMOpenButton.SetActive(true);
        musicData.BGMIsOpen = false;
        GameDataManager.Instance.SaveMusicData();
    }

    public void OnBGMOpen() {
        BGMOpenButton.SetActive(false);
        BGMCloseButton.SetActive(true);
        musicData.BGMIsOpen = true;
        GameDataManager.Instance.SaveMusicData();
    }

    public void ChangeBGMSlider(float value)
    {
        musicData.BGMVolume = value;
        GameDataManager.Instance.SaveMusicData();
    }

    public void OnEffectClose() {
        EffectCloseButton.SetActive(false);
        EffectOpenButton.SetActive(true);
        musicData.EffectIsOpen = false;
        GameDataManager.Instance.SaveMusicData();
    }

    public void OnEffectOpen() {
        EffectOpenButton.SetActive(false);
        EffectCloseButton.SetActive(true);
        musicData.EffectIsOpen = true;
        GameDataManager.Instance.SaveMusicData();
    }

    public void ChangeEffectSlider(float value)
    {
        musicData.EffectVolume = value;
        GameDataManager.Instance.SaveMusicData();
    }

    public void UpdataPanelInfo()
    {
        musicData = GameDataManager.Instance.musicData;
        // BGM按钮显隐设置
        BGMOpenButton.SetActive(!musicData.BGMIsOpen);
        BGMCloseButton.SetActive(musicData.BGMIsOpen);

        // 音效按钮显隐设置
        EffectOpenButton.SetActive(!musicData.EffectIsOpen);
        EffectCloseButton.SetActive(musicData.EffectIsOpen);

        // 设置音量滑动条（范围一般是 0~1）
        if (BGMSlider != null)
            BGMSlider.value = musicData.BGMVolume;

        if (EffectSlider != null)
            EffectSlider.value = musicData.EffectVolume;
    }

    public override void ShowMinePanel()
    {
        base.ShowMinePanel();
        UpdataPanelInfo();
        Time.timeScale = 0;
    }

    public override void HideMinePanel()
    {
        base.HideMinePanel();
        Time.timeScale = 1;
    }
}
