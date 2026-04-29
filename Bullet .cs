using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other .CompareTag("Enemy"))
        {
            Destroy(other .gameObject); // destroy enemy
            Destroy(gameObject); //destroy bullet

            FindObjectOfType<GameManager>() .OnEnemyDestroyed();
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
}
