using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(Shooting))]
public class Player : MonoBehaviour,ITakeDamage
{
    Movement movement;
    Shooting shooting;

    bool canShoot;

    public float shootDelay = 1f;

    private void Awake()
    {
        movement = GetComponent<Movement>();
        shooting = GetComponent<Shooting>();
        canShoot = true;
    }

    private void Update()
    {
        float horizontalImput = Input.GetAxis("Horizontal");

        movement.Move(horizontalImput * Vector2.right);

        if (Input.GetButton("Fire1") && canShoot)
        {
            StartCoroutine(ShootCooldown());
        }
    }
    private IEnumerator ShootCooldown()
    {
        shooting.Shoot();
        canShoot = false;
        yield return new WaitForSeconds(shootDelay);
        canShoot = true;
    }

    public void TakeDamage()
    {
        GameManager.instance.LoseOneLife();
        gameObject.SetActive(false);
    }
}
