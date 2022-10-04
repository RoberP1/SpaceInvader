using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Movement))]
public class Projectile : MonoBehaviour
{
    Movement movement;
    private void Awake()
    {
        movement = GetComponent<Movement>();
    }
    private void FixedUpdate()
    {
        movement.Move(transform.up);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != gameObject.tag)
        {
            collision.GetComponent<ITakeDamage>()?.TakeDamage();
            ProjectilePool.instance.ReturnProyectile(gameObject);
        }
        
    }
}
