using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject playerPrefab;

    public int score;
    public TextMeshProUGUI scoreText;

    public int lives;
    public GameObject[] hearts;

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
        UpdateScore();
    }

    public void AddScore()
    {
        score++;
        UpdateScore();
    }
    public void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void LoseOneLife()
    {
        lives--;
        hearts[lives].SetActive(false);
        if (lives <= 0)
        {
            //game over
        }
        else
        {
            StartCoroutine(Respawn());  

        }
    }
    IEnumerator Respawn()
    {
        Time.timeScale = 0;
        
        foreach (var Projectile in FindObjectsOfType<Projectile>())
        {
            ProjectilePool.instance.ReturnProyectile(Projectile.gameObject);
        }
        
        yield return new WaitForSecondsRealtime(1f);
        Time.timeScale = 1;
        Instantiate(playerPrefab, transform.position, Quaternion.identity);
    }
}
