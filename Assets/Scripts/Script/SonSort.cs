using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class SonSort : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        List<Transform> list = new List<Transform>();
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            list.Add(child);
        }
        //var sortList = list.OrderBy(transform => transform.name.Length).ToList();
        list.Sort((a, b) =>
        { return a.name.Length - b.name.Length; });
        for (int i = 0; i < list.Count; i++)
        {
            Transform item = list[i];
            item.SetSiblingIndex(i);
        }

        Debug.Log(this.MyFindSon(this.transform, "Son_Son_Son_Y")?.name ?? "Ã»ÕÒµ½");
    }

    private Transform MyFindSon(Transform findObj, string findName)
    {
        if (findObj == null) return null;
        if (findObj.childCount == 0) return null;
        for (int i = 0; i < findObj.childCount; i++)
        {
            Transform SonTransform = findObj.GetChild(i);
            if (SonTransform.name == findName) return SonTransform;
        }
        List<Transform> list = new List<Transform>();
        for (int i = 0; i < findObj.childCount; i++)
        {
            Transform SonTransform = findObj.GetChild(i);
            list.Add(SonTransform);
        }
        Transform Target = null;
        list.Any(item => {
            Transform childFind = MyFindSon(item, findName);
            if (childFind != null)
            {
                Target = childFind;
                return true;
            } else
            {
                return false;
            }
        });
        return Target;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
