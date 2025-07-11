using UnityEngine;

public class HealthBarFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 2.5f, 0);
    private Camera mainCam;
    public float baseScale = .6f;
    public float scaleMultiplier = .6f;
    public float minScale = .3f;
    public float maxScale = .8f;

    void Start()
    {
        mainCam = Camera.main;
    }

    void LateUpdate()
    {
        if (target == null || mainCam == null) return;

        Vector3 worldPos = target.position + offset;
        Vector3 screenPos = mainCam.WorldToScreenPoint(worldPos);

        if (screenPos.z > 0)
        {
            transform.position = screenPos;

            // 目标离摄像机越远，UI越小
            float distance = Vector3.Distance(mainCam.transform.position, target.position);
            float scale = baseScale / (distance * scaleMultiplier);
            scale = Mathf.Clamp(scale, minScale, maxScale);
            transform.localScale = new Vector3(scale, scale, scale);
        }
    }
}
