using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    private List<GameObject> polledObjects = new List<GameObject>();
    private int amountToPool = 3;

    [SerializeField] private GameObject bulletPrefab;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(bulletPrefab);
            obj.SetActive(false);
            polledObjects.Add(obj);
        }
    }
   public GameObject GetPooledObject()
    {
        for (int i = 0; i < polledObjects.Count; i++)
        {
            if (!polledObjects[i].activeInHierarchy)
            {
                return polledObjects[i];
            }
        }
        return null;
    }
}
