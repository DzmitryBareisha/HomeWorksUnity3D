using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform target;
    [SerializeField] private float smoothSpeed;
    [SerializeField] private float minX, maxX, minY, maxY;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private void LateUpdate()
    {
        transform.position = Vector2.Lerp(transform.position, new Vector2(target.position.x, target.position.y), smoothSpeed * Time.deltaTime);   
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, minX, maxX), Mathf.Clamp(transform.position.y, minY, maxY));
    }
}
