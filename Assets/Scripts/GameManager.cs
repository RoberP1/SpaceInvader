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
        if (instance == null) instance = this;
        else Destroy(gameObject);
        
        UpdateScore();
        totalEnemies = FindObjectsOfType<Enemy>().Length;
    }

    public void AddScore()
    {
        score++;
        UpdateScore();
        if (score == totalEnemies)
        {
            Win();
        }
    }
    public void UpdateScore() => scoreText.text = "Score: " + score;
    public void LoseOneLife()
    {
        AudioManager.instance.PlayLoseLifeClip();
        
        lives--;
        hearts[lives].SetActive(false);
        
        if (lives <= 0) Lose();
        else StartCoroutine(Respawn());  
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
    public void Win()
    {
        OnWin.Invoke();
        Time.timeScale = 0;
    }
    public void Lose()
    {
        OnLose.Invoke();
        Time.timeScale = 0;
    }
}