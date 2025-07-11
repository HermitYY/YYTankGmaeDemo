using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    public Slider BloodBar;
    private Coroutine healthLerpCoroutine;
    private const float lerpSpeed = 10f;

    public void UpdateHealthUI(float maxHealthValue, float currentHealthValue)
    {
        if (BloodBar == null) return;

        if (BloodBar.maxValue != maxHealthValue)
        {
            BloodBar.maxValue = maxHealthValue;
            BloodBar.value = maxHealthValue;
            return;
        }

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
}
