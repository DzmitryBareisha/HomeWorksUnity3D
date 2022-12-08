using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : SingletonClass<BulletManager>
{
    public int amountToPool = 5;
    public GameObject prefab;
    List<GameObject> pooledObjects;
    private void Awake()
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
    //public void CreatePool()
    //{
    //    prefab = robot.shell;
    //    pooledObjects = new List<GameObject>();
    //    for (int i = 0; i < amountToPool; i++)
    //    {
    //        GameObject obj = Instantiate(prefab);
    //        obj.SetActive(false);
    //        pooledObjects.Add(obj);
    //    }
    //}
}
