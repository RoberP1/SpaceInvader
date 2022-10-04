using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    Enemy[] enemies;
    void Start()
    {
        enemies = FindObjectsOfType<Enemy>();
        InvokeRepeating("Shoot", 2, 1);
    }

    public void Shoot()
    {
        int randomEnemy = Random.Range(0, enemies.Length);
        enemies[randomEnemy].shooting.Shoot();
    }
}
