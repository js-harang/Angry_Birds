using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject deathEffect;

    public float health = 4f;

    public static int enemiesAlive = 0;

    private void Start()
    {
        enemiesAlive++;
    }

    private void OnCollisionEnter2D(Collision2D colInfo)
    {
        if (colInfo.relativeVelocity.magnitude > health)
        {
            Die();
        }
    }

    private void Die()
    {
        SoundManager.sm.Bgm(2);

        Instantiate(deathEffect, transform.position, Quaternion.identity);

        enemiesAlive--;
        if (enemiesAlive <= 0)
            Debug.Log("Clear");

        Destroy(gameObject);
    }
}
