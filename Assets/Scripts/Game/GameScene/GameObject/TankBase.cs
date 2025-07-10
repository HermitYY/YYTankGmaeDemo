using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TankBase : MonoBehaviour
{
    public int atk;
    public int def;
    public int maxHealth;
    public int currentHealth;

    public float moveSpeed = 10;
    public int moveRotaAngularVelocity = 30;
    public int turretRotaAngularVelocity = 60;

    public GameObject turret;
    public GameObject deadEffect;
    public GameObject healthBar;
    protected abstract void Fire();

    protected virtual void Start()
    {
        UpdateHealthUI();
        currentHealth = maxHealth;
    }

    public virtual void Wonnd(TankBase attackTank) {
        int dmg = attackTank.atk - def;

        if (dmg > 0)
        {
            currentHealth -= dmg;
            UpdateHealthUI();
        }
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }

    public void UpdateHealthUI()
    {
        if (healthBar == null) return;
        HealthBar healthBarScript = healthBar?.GetComponent<HealthBar>();
        if (healthBarScript == null) return;
        healthBarScript.UpdateHealthUI(maxHealth, currentHealth);
    }

    protected virtual void Die() {
        PlayDieEffect();
        Destroy(gameObject);
    }

    protected virtual void PlayDieEffect()
    {
        if (deadEffect == null) return;
        GameObject effect = Instantiate(deadEffect, transform.position, transform.rotation);
        GameDataManager.Instance.SetGameObjectEffectAudioSource(effect);
    }
}
