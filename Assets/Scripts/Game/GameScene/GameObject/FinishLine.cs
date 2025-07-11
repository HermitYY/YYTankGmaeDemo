using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerTank>())
        {
            VictoryPanel.Instance.ShowMinePanel();
        }
    }
}
