using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab; // Reference til bullet prefab
    public Transform firePoint; // Det punkt, hvor projektilet skal spawne
    public float bulletSpeed = 10f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Når venstre museknap trykkes
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Instantiate the bullet at the firePoint's position without rotation (Quaternion.identity)
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);  
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // Get the mouse position in world space
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Remove the z-axis value to ensure we are only working with 2D vectors
        mouseWorldPosition.z = 0;

        // Calculate direction from the fire point to the mouse position
        Vector2 shootDirection = (mouseWorldPosition - firePoint.position).normalized;

        // Apply the direction to the bullet's Rigidbody2D (move it in the direction)
        rb.linearVelocity = shootDirection * bulletSpeed; // Using linearVelocity here to avoid deprecated warning

        // Rotate the bullet to face the direction it's traveling
        float angle = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle)); 

        // Log the direction and angle for debugging
        Debug.Log("Shoot Direction: " + shootDirection);
        Debug.Log("Shoot Angle: " + angle);
    }
}
