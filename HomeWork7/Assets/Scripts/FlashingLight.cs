using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashingLight : MonoBehaviour
{
    [SerializeField]
    private Light flashingLight;
    // Start is called before the first frame update
    void Start()
    {
        flashingLight.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        var randomNumber = Random.value;
        if (randomNumber <= 0.2)
        {
            flashingLight.enabled = true;
        }
        else 
        {
            flashingLight.enabled = false;
        }
    }
}
