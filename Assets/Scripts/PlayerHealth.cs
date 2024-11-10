using UnityEngine;
using UnityEngine.UI;
using System.Collections;  // Add this for IEnumerator

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;          // Player's max health
    private float currentHealth;            // Player's current health
    public Image healthFillImage;           // Reference to the health fill image
    public ParticleSystem explosionEffect;  // Reference to the explosion effect

    public bool isDead = false; // To track if the player is dead

    void Start()
    {
        // Initialize health
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void TakeDamage(float damage)
    {
        // Reduce health by damage amount
        currentHealth -= damage;
        // Ensure health doesn’t go below zero
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        // Update the health bar UI
        UpdateHealthBar();

        // Check if the player is dead
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateHealthBar()
    {
        if (healthFillImage != null)
        {
            // Set the fill amount based on current health
            healthFillImage.fillAmount = currentHealth / maxHealth;
        }
    }

    void Die()
    {
        Debug.Log("Player is dead.");

        isDead = true; // Mark the player as dead

        // Play the explosion effect
        if (explosionEffect != null)
        {
            explosionEffect.transform.position = transform.position;  // Position explosion at player's location
            explosionEffect.Play();  // Play the explosion effect
        }

        // Disable player movement (if you have one)
        var playerMovement = GetComponent<PlayerMovement>();
        if (playerMovement != null)
        {
            playerMovement.enabled = false;
        }

        // Wait for 5 seconds before destroying the player and showing the restart button
        StartCoroutine(HandlePlayerDeath());
    }

    private IEnumerator HandlePlayerDeath()
    {
        // Wait for 5 seconds
        yield return new WaitForSeconds(5f);

        // Destroy the player after 5 seconds
        Destroy(gameObject);

        // Show the restart button
        // Ensure GameManager is correctly referenced
        if (GameManager.Instance != null)
        {
            GameManager.Instance.ShowRestartButton(); // Call a method from your GameManager to show the button
        }
    }
}
