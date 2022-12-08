using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
public class Sphere : MonoBehaviour
{
    private IObjectPool<Sphere> _pool;
    
    private float _timeToDestroy = 5f;
    [HideInInspector] public Rigidbody _rigidbody;
    
    void Awake()
    {
       _rigidbody = GetComponent<Rigidbody>(); 
    }
    void Update()
    {        
        _timeToDestroy -= Time.deltaTime;
        if (_timeToDestroy < 0)
        {
            if (_pool != null)
            {
                _timeToDestroy = 5f;
                _pool.Release(this);
            }
            else 
            {
                Destroy(gameObject);
            }
        }
    }    
    public void SetPool(IObjectPool<Sphere> pool) => _pool = pool;
}
