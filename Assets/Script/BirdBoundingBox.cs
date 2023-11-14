using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBoundingBox : MonoBehaviour
{
    public float width = 0.2f;    // Adjust these values based on the size of your bird
    public float height = 0.2f;

    // Update is called once per frame
    void Update()
    {
        // Check for collisions with the ground or other objects
        CheckCollision();
    }

    void CheckCollision()
    {
        // Get the current position of the bird
        Vector2 currentPosition = transform.position;

        // Calculate the half extents of the bounding box
        Vector2 halfExtents = new Vector2(width / 2f, height / 2f);

        // Example: Check for collisions with the ground (assuming ground level is at y = 0)
        float groundLevel = -4f;
        if (currentPosition.y - halfExtents.y < groundLevel && currentPosition.y + halfExtents.y > groundLevel)
        {
            HandleCollision();
        }

        // Example: Check for collisions with another object
        GameObject[] otherObjects = GameObject.FindGameObjectsWithTag("Ground");
        foreach (GameObject otherObject in otherObjects)
        {
            BirdBoundingBox otherCollider = otherObject.GetComponent<BirdBoundingBox>();
            if (otherCollider != null && CheckOverlap(currentPosition, halfExtents, otherObject.transform.position, otherCollider.width, otherCollider.height))
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

        float combinedWidth = (sizeA.x + widthB) /2f;
        float combinedHeight = (sizeA.y + heightB) / 2f;

        return distanceX < combinedWidth && distanceY < combinedHeight;
    }

    void HandleCollision()
    {
        // Handle the collision
        Debug.Log("Bird Collision detected!");
        // Add your logic for what happens when a collision is detected
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
