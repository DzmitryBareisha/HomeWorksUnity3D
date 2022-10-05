using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        CharacterController character = collider.GetComponent<CharacterController>();
        if (character)
        {
            character.RecieveDamage();
        }
    }
}
