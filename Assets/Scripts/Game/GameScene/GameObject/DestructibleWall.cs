using UnityEngine;



public class DestructibleWall : TankBase
{
    [Header("Drop Settings")]
    [Tooltip("总体掉落概率 (0-100)")]
    [Range(0, 100)] public float dropChance = 30f; // 默认30%概率掉落物品
    [Tooltip("可能掉落的物品列表")]
    public GameObject[] dropItems; // 掉落物品数组

    protected override void Fire() { }

    protected override void Die()
    {
        TryDropItem();
        GamePanel.Instance.AddSorce(1);
        base.Die();
    }

    private void TryDropItem()
    {
        // 随机检测是否掉落
        if (dropItems == null || dropItems.Length == 0 || Random.Range(0, 100) > dropChance)
            return;

        // 从列表中随机选择物品
        int index = Random.Range(0, dropItems.Length);
        GameObject dropPrefab = dropItems[index];

        // 在墙壁位置生成物品
        if (dropPrefab != null)
        {
            Instantiate(dropPrefab, transform.position, Quaternion.identity);
        }
    }
}
