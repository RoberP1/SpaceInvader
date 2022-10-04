using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    private void Start() => rb = GetComponent<Rigidbody2D>();
    public void Move(Vector2 direction) => rb.velocity = direction * speed;
}
