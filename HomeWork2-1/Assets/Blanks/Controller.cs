using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject obj;
    public int level = 2;    
    void Start()
    {
        Instance();         
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instance();            
        }        
    }
    void Instance()
    {        
        transform.position = new Vector3 (transform.position.x, level, transform.position.z);
        Instantiate(obj, transform.position, Quaternion.identity);
        level += 2;        
    }   
}
