using UnityEngine;

public class WeaponRewardBox : RewardBoxBase
{
    [SerializeField] private GameObject[] RandomWeaponObjPool;

    protected override void OnTriggerPlayer(PlayerTank playerObj)
    {
        base.OnTriggerPlayer(playerObj);
        int index = Random.Range(0, RandomWeaponObjPool.Length);
        GameObject weapon = RandomWeaponObjPool[index];
        if (weapon == null) return;
        playerObj.ChangeWeapon(weapon);
        Destroy(this.gameObject);
    }
}
