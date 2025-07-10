using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardBoxBase : MonoBehaviour
{
    [SerializeField] private float liveTime;
    [SerializeField] private GameObject pickUpEffect;
    private void OnTriggerEnter(Collider other)
    {
        PlayerTank playerTank = GetComponent<PlayerTank>();
        if (playerTank != null)
        {
            OnTriggerPlayer(playerTank);
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

    protected virtual void OnTriggerPlayer(PlayerTank playerObj)
    {
        PlayEffect(playerObj.gameObject.transform);
    }
}
