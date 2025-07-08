using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : BasePanel<GamePanel>
{
    public Slider BloodBar;
    private Coroutine healthLerpCoroutine;
    private const float lerpSpeed = 10f;

    public TextMeshProUGUI TimeText;
    [HideInInspector]
    public float nowTime;

    public TextMeshProUGUI SorceText;
    [HideInInspector]
    public int currentSorce;

    void Start()
    {
        
    }

    void Update()
    {
        nowTime += Time.deltaTime;
        UpdateTime();
    }

    public void OnSettingButton() {
        SettingPanel.Instance.ShowMinePanel();
    }

    public void OnExitButton() { }

    public void UpdateHealthUI(float maxHealthValue, float currentHealthValue)
    {
        if (BloodBar == null) return;

        BloodBar.maxValue = maxHealthValue;

        if (healthLerpCoroutine != null)
        {
            StopCoroutine(healthLerpCoroutine);
        }

        healthLerpCoroutine = StartCoroutine(LerpHealth(BloodBar.value, currentHealthValue));
    }

    private IEnumerator LerpHealth(float startValue, float targetValue)
    {
        float elapsedTime = 0f;
        while (elapsedTime < 1f)
        {
            elapsedTime += Time.deltaTime * lerpSpeed;
            BloodBar.value = Mathf.Lerp(startValue, targetValue, elapsedTime);
            yield return null;
        }
        BloodBar.value = targetValue;
    }

    private void UpdateTime()
    {
        TimeText.text = nowTime.ToString("0.0") + " Ãë";
    }
}
