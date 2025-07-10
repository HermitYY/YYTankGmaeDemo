using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRewaedBox : MonoBehaviour
{
    [SerializeField] private GameObject[] RandomWeaponObjPool;
    [SerializeField] private float liveTime;
    [SerializeField] private GameObject pickUpEffect;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerTank>() != null)
        {
            int index = Random.Range(0, RandomWeaponObjPool.Length);
            GameObject weapon = RandomWeaponObjPool[index];
            if (weapon == null) return;
            other.GetComponent<PlayerTank>().ChangeWeapon(weapon);
            PlayEffect(other.transform);
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        liveTime -= Time.deltaTime;
        if (liveTime < 0)
        {
            liveTime = 0;
            Destroy(this.gameObject);
        }
    }

    private void PlayEffect(Transform playerPos)
    {
        if (pickUpEffect == null) return;
        GameObject effect = Instantiate(pickUpEffect, playerPos.position, playerPos.rotation);
        GameDataManager.Instance.SetGameObjectEffectAudioSource(effect);
    }
}
