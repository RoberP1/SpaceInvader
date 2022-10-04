using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHP : MonoBehaviour, ITakeDamage
{
    public int maxHP = 3;
    public int currentHP;
    public GameObject[] hearts;



    private void Start()
    {
        currentHP = maxHP;
    }

    public void TakeDamage()
    {
        currentHP--;
        //hearts[currentHP].SetActive(false);
        if (currentHP <= 0)
        {
            //llamar al la instancia de la clase gamemanager, perder
        }
        else
        {
            //llamar al la instancia de la clase gamemanager, instanciar nuevo player
        }
    }
}
