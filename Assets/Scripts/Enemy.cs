using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Shooting))]
public class Enemy : MonoBehaviour,ITakeDamage
{
    public Shooting shooting;

    public void TakeDamage()
    {
        GameManager.instance.AddScore();
        FindObjectOfType<EnemyShooter>().enemies.Remove(this);
        AudioManager.instance.PlayInvaderKilledClip();
        gameObject.SetActive(false);
    }

    private void Start()
    {
        shooting = GetComponent<Shooting>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.instance.Lose();
        }
    }
}
