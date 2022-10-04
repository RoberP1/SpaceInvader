using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject playerPrefab;

    public int score;
    public TextMeshProUGUI scoreText;

    public int lives;
    public GameObject[] hearts;

    public int totalEnemies;

    public UnityEvent OnWin = new UnityEvent();
    public UnityEvent OnLose = new UnityEvent();

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
        totalEnemies = FindObjectsOfType<Enemy>().Length;
    }

    public void AddScore()
    {
        score++;
        UpdateScore();
        if (score == totalEnemies)
        {
            OnWin.Invoke();
            Time.timeScale = 0;
        }
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
            OnLose.Invoke();
            Time.timeScale = 0;
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
        
        yield return new WaitForSecondsRealtime(2f);
        Time.timeScale = 1;
        Instantiate(playerPrefab, transform.position, Quaternion.identity);
    }
}
