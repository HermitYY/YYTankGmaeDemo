using UnityEngine;

public class TankWeapon : MonoBehaviour
{
    public GameObject bulletPrefab;

    public Transform[] shootPos;

    public void Shoot()
    {
        foreach (var item in shootPos)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.GetComponent<Bullet>()?.SetUp(item.position, item.rotation, GetComponentInParent<TankBase>());
        }
    }
}
