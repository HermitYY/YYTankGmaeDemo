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
    protected abstract void Fire();

    protected virtual void Wonnd(TankBase attackTank) {
        int dmg = attackTank.atk - def;
        if (dmg > 0)
        {
            currentHealth -= dmg;
        }
        if (currentHealth < 0)
        {
            currentHealth = 0;
            Die();
        }
    }

    protected virtual void Die() {
        PlayDieEffect();
        Destroy(gameObject);
    }

    protected virtual void PlayDieEffect()
    {
        if (deadEffect == null) return;
        GameObject effect = Instantiate(deadEffect, transform.position, transform.rotation);
        AudioSource audioSource = effect.GetComponent<AudioSource>();
        audioSource.mute = !GameDataManager.Instance.musicData.EffectIsOpen;
        audioSource.volume = GameDataManager.Instance.musicData.EffectVolume;
    }
}
