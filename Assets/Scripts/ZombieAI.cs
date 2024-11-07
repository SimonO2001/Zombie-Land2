using UnityEngine;
using UnityEngine.UI;

public class ZombieAI : MonoBehaviour
{
    public float moveSpeed = 2f;          // Speed of the zombie movement
    public float chaseRadius = 10f;       // Distance at which the zombie will start chasing the player
    public float maxHealth = 2f;          // Maximum health for the zombie
    public float damageFromZombie = 1f;   // Damage the zombie deals to the player on contact

    private float currentHealth;          // Current health of the zombie
    public Image healthBarFill;           // Reference to the health bar fill image

    private Transform player;             // Reference to the player's transform
    private Rigidbody2D rb;

    void Start()
    {
        // Initialize health
        currentHealth = maxHealth;

        // Find the player in the scene
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();

        // Update the health bar to show full health at the start
        UpdateHealthBar();
    }

    void Update()
    {
        // Check if the player is within the chase radius
        if (Vector2.Distance(transform.position, player.position) < chaseRadius)
        {
            MoveTowardsPlayer();
        }
    }

    void MoveTowardsPlayer()
    {
        // Calculate the direction to the player
        Vector2 direction = (player.position - transform.position).normalized;

        // Move the zombie towards the player
        rb.linearVelocity = direction * moveSpeed;
    }

    public void TakeDamage(float damage)
    {
        // Reduce health
        currentHealth -= damage;
        Debug.Log("Zombie took damage. Current Health: " + currentHealth);

        // Update the health bar to reflect the new health
        UpdateHealthBar();

        // Check if the zombie's health has reached zero
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateHealthBar()
    {
        if (healthBarFill != null)
        {
            float healthPercentage = currentHealth / maxHealth;
            healthBarFill.fillAmount = healthPercentage;
        }
        else
        {
            Debug.LogWarning("Health Bar Fill Image is not assigned in ZombieAI script!");
        }
    }

    void Die()
    {
        // Destroy the zombie when health reaches zero
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Call TakeDamage on the player when the zombie collides with the player
            PlayerHealth player = collision.GetComponent<PlayerHealth>();
            if (player != null)
            {
                player.TakeDamage(damageFromZombie);
            }
        }
    }
}
