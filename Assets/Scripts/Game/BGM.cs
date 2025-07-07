using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    private static BGM _instance;
    public static BGM Instance => _instance;

    private AudioSource audioSource;

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this);
            return;
        }
        _instance = this;
        audioSource = GetComponent<AudioSource>();
        ChangeValue(GameDataManager.Instance.musicData.BGMVolume);
        ChangeOpen(GameDataManager.Instance.musicData.BGMIsOpen);
    }

    protected virtual void OnDestroy()
    {
        if (_instance == this)
        {
            _instance = null;
        }
    }

    void Start()
    {
        
    }

    public void ChangeValue(float value)
    {
        audioSource.volume = value;
    }

    public void ChangeOpen(bool isOpen)
    {
        audioSource.mute = !isOpen;
    }
}
