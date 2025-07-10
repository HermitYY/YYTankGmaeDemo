using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EAttrRewardBoxType
{
    ATK,
    DEF,
    SPEED,
    HEALTH,
}
public class AttrRewardBox : RewardBoxBase
{
    [SerializeField] private EAttrRewardBoxType type;
    [SerializeField] private float attrValue;
    protected override void OnTriggerPlayer(PlayerTank playerObj)
    {
        base.OnTriggerPlayer(playerObj);
        ProvideAttr(playerObj);
        Destroy(this.gameObject);
    }

    private void ProvideAttr(PlayerTank playerObj)
    {
        switch (type)
        {
            case EAttrRewardBoxType.ATK:
                playerObj.atk += (int)attrValue;
                break;
            case EAttrRewardBoxType.DEF:
                playerObj.def += (int)attrValue;
                break;
            case EAttrRewardBoxType.SPEED:
                playerObj.moveSpeed += attrValue;
                break;
            case EAttrRewardBoxType.HEALTH:
                int health = playerObj.currentHealth + (int)attrValue;
                playerObj.currentHealth = Mathf.Min(health, playerObj.maxHealth);
                playerObj.UpdateHealthUI();
                break;

        }
    }
}
