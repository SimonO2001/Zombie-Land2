using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 2f;  // Lifetime of the bullet before it disappears
    public float damage = 1f;  // Damage dealt to zombies

    private Vector2 direction; // The direction the bullet is moving

    void Start()
    {
        // Destroy the bullet after its lifetime
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        // Move the bullet forward
        
    }

    public void SetDirection(Vector2 shootDirection)
    {
        // Set the direction of the bullet
        direction = shootDirection.normalized;

        // Rotate the bullet in the direction of travel
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Zombie"))
        {
            // Call TakeDamage on the zombie when the bullet hits it
            ZombieAI zombie = collision.GetComponent<ZombieAI>();
            if (zombie != null)
            {
                zombie.TakeDamage(damage);
            }

            // Destroy the bullet
            Destroy(gameObject);
        }

        // Ignore the player (no damage to player)
        if (collision.CompareTag("Player"))
        {
            return;
        }
    }
}
