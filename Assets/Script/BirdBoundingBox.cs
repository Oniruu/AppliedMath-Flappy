using UnityEngine;

public class BirdBoundingBox : MonoBehaviour
{
    public float width = 0.2f;
    public float height = 0.2f;

    // Update is called once per frame
    void Update()
    {
        // Check for collisions with the ground or pipes
        CheckCollision();
    }

    void CheckCollision()
    {
        // Get the current position of the bird
        Vector2 currentPosition = transform.position;

        // Calculate the half extents of the bounding box
        Vector2 halfExtents = GetHalfExtents();

        // Check for collisions with the ground
        float groundLevel = -4f;
        if (currentPosition.y - halfExtents.y < groundLevel && currentPosition.y + halfExtents.y > groundLevel)
        {
            HandleCollision();
        }

        // Check for collisions with pipes
        GameObject[] pipes = GameObject.FindGameObjectsWithTag("Pipe");
        foreach (GameObject pipe in pipes)
        {
            BirdBoundingBox pipeCollider = pipe.GetComponent<BirdBoundingBox>();
            if (pipeCollider != null && CheckOverlap(currentPosition, halfExtents, pipe.transform.position, pipeCollider.width, pipeCollider.height))
            {
                HandleCollision();
            }
        }
    }

    bool CheckOverlap(Vector2 posA, Vector2 sizeA, Vector2 posB, float widthB, float heightB)
    {
        // Check for overlap between two bounding boxes
        float distanceX = Mathf.Abs(posA.x - posB.x);
        float distanceY = Mathf.Abs(posA.y - posB.y);

        float combinedWidth = (sizeA.x + widthB) / 2f;
        float combinedHeight = (sizeA.y + heightB) / 2f;

        return distanceX < combinedWidth && distanceY < combinedHeight;
    }

    void HandleCollision()
    {
        // Handle the collision
        Debug.Log("Bird Collision detected!");

        // Freeze the game by setting the time scale to 0
        Time.timeScale = 0;
        Debug.Log("Game Over!");
    }

    public Vector2 GetHalfExtents()
    {
        return new Vector2(width / 2f, height / 2f);
    }

    // Visualize the bounding box in the Scene view
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 1f));
    }
}