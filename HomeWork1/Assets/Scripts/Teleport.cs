using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    private float updateTime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        updateTime -= Time.deltaTime;
        if (updateTime < 0f)
        {
            var rotation = Quaternion.identity;
            var position = new Vector3(Random.Range(-5.0f, 5.0f), Random.Range(-5.0f, 5.0f), Random.Range(-5.0f, 5.0f));
            //instance = Instantiate(prefab, position, rotation);
            updateTime = 5f;
        }
    }
}
