using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float speed = 2.0f;
    private SpriteRenderer sprite;
    private Vector3 direction;
    public SpriteRenderer Sprite { get { return sprite = sprite ?? GetComponentInChildren<SpriteRenderer>(); } }
    private void Start()
    {
        direction = transform.right;
    }
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.5f + transform.right * direction.x * 0.7f, 0.1f);
        if (colliders.Length > 0 && colliders.All(x => !x.GetComponent<CharacterController>()))
        {
            direction *= -1.0f;
        }
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {

        CharacterController character = collider.GetComponent<CharacterController>();
        if (character)
        {
            character.RecieveDamage();
        }
    }

}
