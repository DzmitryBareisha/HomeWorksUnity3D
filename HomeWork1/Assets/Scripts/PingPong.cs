using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPong : MonoBehaviour
{
    public float speed = 9.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0f, 0f);
        if (transform.position.x > 10f)
        {
            speed = -speed;
        }
        if (transform.position.x < -10f)
        {
            speed = -speed;
        }
    }
}
