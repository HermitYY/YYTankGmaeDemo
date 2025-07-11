using UnityEngine;

public class BasePanel<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    public static T Instance => _instance;

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this);
            return;
        }
        _instance = this as T;
    }

    protected virtual void OnDestroy()
    {
        if (_instance == this)
        {
            _instance = null;
        }
    }

    public virtual void ShowMinePanel()
    {
        this.gameObject.SetActive(true);
    }

    public virtual void HideMinePanel()
    {
        this.gameObject.SetActive(false);
    }
}
