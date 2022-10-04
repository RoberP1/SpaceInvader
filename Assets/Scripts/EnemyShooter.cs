using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyShooter : MonoBehaviour
{
    public List<Enemy> enemies;
    void Start()
    {
        enemies = FindObjectsOfType<Enemy>().ToList();
        InvokeRepeating("Shoot", 2, 1);
    }

    public void Shoot()
    {
        int randomEnemy = Random.Range(0, enemies.Count);
        enemies[randomEnemy].shooting.Shoot();
    }
}
