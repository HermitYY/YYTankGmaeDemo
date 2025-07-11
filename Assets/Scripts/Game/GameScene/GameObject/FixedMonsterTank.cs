using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedMonsterTank : TankBase
{
    [SerializeField] float AttackInterval;
    private float AttackIntervalTimer;
    protected override void Fire()
    {
        if (weapon == null) return;
        weapon.Shoot();
    }

    private void Update()
    {
        if (AttackIntervalTimer < 0)
        {
            Fire();
            AttackIntervalTimer = AttackInterval;
            return;
        }
        AttackIntervalTimer -= Time.deltaTime;
    }

    protected override void Die()
    {
        GamePanel.Instance.AddSorce(5);
        base.Die();
    }
}
