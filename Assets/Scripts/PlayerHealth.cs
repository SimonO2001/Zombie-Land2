using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 5f;  // Player's health
    public float damageFromZombie = 1f; // Damage dealt by zombies

    void Update()
    {
        // For now, just log health for debugging
        Debug.Log("Player Health: " + health);
    }

    // Function to take damage from zombies
    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();  // Call Die() if the player's health reaches 0
        }
    }

    void Die()
    {
        // Display a simple message, or implement a game-over screen
        Debug.Log("Player has died.");
        // Optionally, destroy the player object
        Destroy(gameObject);
    }
}
