using UnityEngine;

public class ArenaSetup : MonoBehaviour
{
    public GameObject Wall; // A prefab for the wall
    public float arenaWidth = 60f;
    public float arenaHeight = 40f;

    void Start()
    {
        // Create the walls (top, bottom, left, right)
        CreateWall(new Vector2(0, arenaHeight / 2), new Vector2(arenaWidth, 1)); // Top Wall
        CreateWall(new Vector2(0, -arenaHeight / 2), new Vector2(arenaWidth, 1)); // Bottom Wall
        CreateWall(new Vector2(-arenaWidth / 2, 0), new Vector2(1, arenaHeight)); // Left Wall
        CreateWall(new Vector2(arenaWidth / 2, 0), new Vector2(1, arenaHeight)); // Right Wall
    }

    void CreateWall(Vector2 position, Vector2 size)
    {
        GameObject wall = Instantiate(Wall, position, Quaternion.identity);
        wall.transform.localScale = new Vector3(size.x, size.y, 1);
        wall.AddComponent<BoxCollider2D>(); // Add collider
    }
}
