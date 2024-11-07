using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Hent Rigidbody2D komponent
    }

    void FixedUpdate()
    {
        // Hent input for bevægelse
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Skab en bevægelsesvektor
        Vector2 movement = new Vector2(horizontal, vertical) * speed;

        // Opdater spillerens position ved hjælp af Rigidbody2D
        rb.linearVelocity = movement;  // Brug velocity i stedet for MovePosition for fysikopdatering
    }
}