using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaler : MonoBehaviour
{
    private GameObject prefab;
    public float increase = 0.2f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.localScale += new Vector3(increase, increase, increase)*Time.deltaTime;
    }
}
