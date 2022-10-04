using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class EnemyMover : MonoBehaviour
{
    Movement movement;
    Enemy[] enemies;
    int movingDirection;
    public LayerMask limit;
    void Start()
    {
        movingDirection = 1;
        enemies = FindObjectsOfType<Enemy>();
        movement = GetComponent<Movement>();
    }
    private void FixedUpdate()
    {
        movement.Move(Vector2.right * movingDirection);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Limit"))
        {
            movingDirection *= -1;
            foreach (Enemy enemy in enemies)
            {
                enemy.transform.position += Vector3.down * 0.5f;
            }
        }
    }
}
