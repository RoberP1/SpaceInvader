using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float proyectileSpeed;
    public void Shoot()
    {
        GameObject proyectile = ProjectilePool.instance.GetProyectile();
        proyectile.tag = gameObject.tag;
        proyectile.transform.position = transform.position;
        proyectile.transform.rotation = transform.rotation;
        proyectile.GetComponent<Movement>().speed = proyectileSpeed;
        AudioManager.instance.PlayClip(AudioManager.instance.shootClip);
    }
}
