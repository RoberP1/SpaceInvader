using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject playerPrefab;

    public int pointsPerEnemy = 50;
    public int score;
    public TextMeshProUGUI scoreText;

    public int lives;
    public GameObject[] hearts;

    public int enemies;

    public UnityEvent OnWin = new UnityEvent();
    public UnityEvent OnLose = new UnityEvent();
    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
        
        UpdateScore();
        enemies = FindObjectsOfType<Enemy>().Length;
    }
    public void AddScore()
    {
        score += pointsPerEnemy;
        enemies--;
        UpdateScore();
        if (enemies <= 0) Win();
    }
    public void UpdateScore() => scoreText.text = "Score: " + score;
    public void LoseOneLife()
    {
        AudioManager.instance.PlayClip(AudioManager.instance.loseLifeClip);

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