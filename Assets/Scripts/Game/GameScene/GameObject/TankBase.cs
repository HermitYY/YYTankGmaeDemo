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
    public GameObject healthBarPrefab;

    protected TankWeapon weapon;
    protected abstract void Fire();

    protected virtual void Start()
    {
        weapon = GetComponentInChildren<TankWeapon>();
        InitHealthBar();
        UpdateHealthUI();
        currentHealth = maxHealth;
    }

    public virtual void Wonnd(TankBase attackTank)
    {
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

    private void InitHealthBar()
    {

        if (healthBar == null)
        {
            GameObject canvasRoot = GameObject.Find("HealthBarRoot");

            if (healthBarPrefab != null && canvasRoot != null)
            {
                healthBar = Instantiate(healthBarPrefab, canvasRoot.transform);
                var follow = healthBar.GetComponent<HealthBarFollow>();
                follow.target = this.transform;
            }
        }

    }

    public void UpdateHealthUI()
    {
        if (healthBar == null) return;
        HealthBar healthBarScript = healthBar.GetComponent<HealthBar>();
        if (healthBarScript == null) return;
        healthBarScript.UpdateHealthUI(maxHealth, currentHealth);
    }

    protected virtual void Die()
    {
        if (healthBar != null)
        {
            Destroy(healthBar);
        }

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
