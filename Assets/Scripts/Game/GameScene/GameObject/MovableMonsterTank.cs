using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableMonsterTank : TankBase
{
    [SerializeField] private Vector3[] movePoint;
    private Vector3 currentMovePoint;
    private int currentSelect;

    [SerializeField] float AttackInterval;
    private float AttackIntervalTimer;

    [SerializeField] int fireDis;
    [SerializeField] int viewDis;

    void Update()
    {
        AttackIntervalTimer -= Time.deltaTime;
    }

    private void FixedUpdate()
    {
        Move();
        CheckForScriptInRange();

    }

    protected override void Fire()
    {
        if (AttackIntervalTimer < 0)
        {
            AttackIntervalTimer = AttackInterval;
            if (weapon == null) return;
            weapon.Shoot();
        }
    }

    private void Move()
    {
        if (movePoint.Length == 0) return;
        if (currentMovePoint == Vector3.zero)
        {
            currentMovePoint = movePoint[currentSelect];
        }

        Vector3 direction = (currentMovePoint - transform.position).normalized;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), Time.fixedDeltaTime * 5f);
        transform.position = Vector3.MoveTowards(transform.position, currentMovePoint, moveSpeed * Time.fixedDeltaTime);

        if (Vector3.Distance(transform.position, currentMovePoint) < 0.1f)
        {
            currentSelect = (currentSelect + 1) % movePoint.Length;
            currentMovePoint = movePoint[currentSelect];
        }
    }

    private void CheckForScriptInRange()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, viewDis);

        foreach (Collider col in colliders)
        {
            if (col.GetComponent<PlayerTank>() != null)
            {
                turret.transform.LookAt(col.transform.position);
                if (Vector3.Distance(transform.position, col.transform.position) < fireDis )
                {
                    Fire();
                } 
                return;
            }
        }
        turret.transform.LookAt(transform.position + transform.forward);
    }

    protected override void Die()
    {
        GamePanel.Instance.AddSorce(10);
        base.Die();
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, viewDis);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, fireDis);
        Gizmos.color = Color.green;
        foreach (var point in movePoint)
        {
            Gizmos.DrawSphere(point, 0.2f);
        }
    }
}
