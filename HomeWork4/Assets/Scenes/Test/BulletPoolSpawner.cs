using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BulletPoolSpawner : MonoBehaviour
{
    public Sphere ObjectToSpawn;
    private ObjectPool<Sphere> _pool;
    void Awake()
    {
        _pool = new ObjectPool<Sphere>(CreateSphere, OnTakeSphereFromPool, OnReturnSphereFromPool);
    }    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetSphere();
        }
    }
    private void OnReturnSphereFromPool(Sphere sphere)
    {
        sphere.gameObject.SetActive(false);
        sphere._rigidbody.isKinematic = true;
    }
    private void OnTakeSphereFromPool(Sphere sphere)
    {
        sphere.gameObject.SetActive(true);
        sphere.transform.position = transform.position;        
        sphere._rigidbody.isKinematic = false;
    }
    private Sphere CreateSphere()
    {
        var sphere = Instantiate(ObjectToSpawn, transform);
        sphere.SetPool(_pool);
        return sphere;
    }
    private void GetSphere()
    {
        var sphere = _pool.Get();
        print("Count activate" + _pool.CountActive);
        print("Count inactive" + _pool.CountInactive);
    }
}
