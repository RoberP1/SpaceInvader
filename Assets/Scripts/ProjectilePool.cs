using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePool : MonoBehaviour
{
    public static ProjectilePool instance;
    public int startProyectiles = 5;

    public GameObject proyectilePrefab;

    private Queue<GameObject> proyectiles = new Queue<GameObject>();

    private void Awake()
    {
        //singleton 
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        for (int i = 0; i < startProyectiles; i++)
        {
            GameObject proyectile = Instantiate(proyectilePrefab, transform);
            proyectile.SetActive(false);
            proyectiles.Enqueue(proyectile);
        }
    }

    public GameObject GetProyectile()
    {
        if (proyectiles.Count == 0)
        {
            GameObject proyectile = Instantiate(proyectilePrefab);
            proyectile.SetActive(false);
            proyectiles.Enqueue(proyectile);
        }

        GameObject proyectileToReturn = proyectiles.Dequeue();
        proyectileToReturn.SetActive(true);
        return proyectileToReturn;
    }

    public void ReturnProyectile(GameObject proyectile)
    {
        proyectile.SetActive(false);
        proyectiles.Enqueue(proyectile);
    }
}
