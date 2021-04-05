using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjPool : Pool
{
    public List<Pool> objectPool = new List<Pool>();
    void Awake()
    {
        for (int i = 0; i < objectPool.Count; i++)
        {
            objectPool[i].Initialize(transform);
        }
    }

    public bool PushToPool(string itemName, GameObject item, Transform parent = null)
    {
        Pool pool = GetPoolItem(itemName);
        if (pool == null)
            return false;

        pool.PushToPool(item, parent == null ? transform : parent);
        return true;
    }

    public GameObject PopFromPool(string itemName, Transform parent = null)
    {
        Pool pool = GetPoolItem(itemName);
        if (pool == null)
            return null;

        return pool.PopFromPool(parent);
    }
    Pool GetPoolItem(string itemName)
    {
        for (int ix = 0; ix < objectPool.Count; ++ix)
        {
            if (objectPool[ix].poolItemName.Equals(itemName))
                return objectPool[ix];
        }

        Debug.LogWarning("There's no matched pool list.");
        return null;
    }
}
