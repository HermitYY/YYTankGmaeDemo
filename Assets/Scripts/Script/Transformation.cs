using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transformation : MonoBehaviour
{
    private List<GameObject> bullets = new List<GameObject>();
    private List<GameObject> bulletSons = new List<GameObject>();

    void Start()
    {

    }

    void Update()
    {
        for (int i = 0; i < bullets.Count; i++)
        {
            GameObject bullet = bullets[i];
            bullet.transform.Translate(bullet.transform.forward * Time.deltaTime * 3, Space.World);
            GameObject bulletSon = bulletSons[i];
            bulletSon.transform.RotateAround(bullet.transform.position, bullet.transform.forward, 300 * Time.deltaTime);
        }
    }

    [ContextMenu("自身当前坐标系前方创建炮弹")]
    private void CreateBullet()
    {
        Vector3 position = transform.TransformPoint(Vector3.forward * 3);
        GameObject bullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        this.bullets.Add(bullet);
        bullet.transform.position = position;
        bullet.transform.localEulerAngles = transform.localEulerAngles;
        GameObject bulletSon = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        bulletSon.transform.position = new Vector3(bullet.transform.position.x + 1, bullet.transform.position.y, bullet.transform.position.z + 1);
        bulletSon.transform.SetParent(bullet.transform, true);
        bulletSon.transform.localScale = Vector3.one * .3f;
        this.bulletSons.Add(bulletSon);
    }
}
