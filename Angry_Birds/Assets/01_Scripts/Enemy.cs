using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 4f;

    private void OnCollisionEnter2D(Collision2D colInfo)
    {
        if (colInfo.relativeVelocity.magnitude > health)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
