using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public void Shoot()
    {
        GameObject proyectile = ProjectilePool.instance.GetProyectile();
        proyectile.transform.position = transform.position;
        proyectile.transform.rotation = transform.rotation;
    }
}
