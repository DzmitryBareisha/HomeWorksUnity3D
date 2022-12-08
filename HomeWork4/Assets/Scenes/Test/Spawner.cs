using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CustomUpdate());
    }

    IEnumerator CustomUpdate()
    {
        while (true)
        {
            var go = Instantiate<GameObject>(prefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(2.0f);
        }
    }     
}
