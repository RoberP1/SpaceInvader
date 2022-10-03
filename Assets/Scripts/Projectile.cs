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
    void Update()
    {
        movement.Move(transform.up);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ProjectilePool.instance.ReturnProyectile(gameObject);
    }
}
