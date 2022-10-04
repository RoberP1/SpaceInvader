using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Shooting))]
public class Enemy : MonoBehaviour,ITakeDamage
{
    public Shooting shooting;

    public void TakeDamage()
    {
        gameObject.SetActive(false);
    }

    private void Start()
    {
        shooting = GetComponent<Shooting>();
    }
}
