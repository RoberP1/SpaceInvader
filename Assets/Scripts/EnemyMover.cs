using UnityEngine;

[RequireComponent(typeof(Movement))]
public class EnemyMover : MonoBehaviour
{
    Movement movement;
    Enemy[] enemies;
    int movingDirection;
    float downDistance = 0.5f;
    void Start()
    {
        movingDirection = 1;
        enemies = FindObjectsOfType<Enemy>();
        movement = GetComponent<Movement>();
    }
    private void FixedUpdate() =>
        movement.Move(Vector2.right * movingDirection);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Limit")
        {
            movingDirection *= -1;
            foreach (Enemy enemy in enemies)
            {
                enemy.transform.position += Vector3.down * downDistance;
            }
        }
    }
}
