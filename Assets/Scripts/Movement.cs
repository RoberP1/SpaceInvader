using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public void Move(Vector2 direction)
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
