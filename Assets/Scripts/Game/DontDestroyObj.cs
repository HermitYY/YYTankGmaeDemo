using UnityEngine;

public class DontDestroyObj : MonoBehaviour
{
    private static DontDestroyObj instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}