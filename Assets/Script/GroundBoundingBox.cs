using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundBoundingBox : MonoBehaviour
{
    public float width = 1.5f;    // Adjust these values based on the size of your ground
    public float height = 0.5f;

    void Update()
    {
        // Check for collisions with the bird or other objects
        CheckCollision();
    }

    void CheckCollision()
    {
        // Get the current position of the ground
        Vector2 currentPosition = transform.position;

        // Calculate the half extents of the bounding box
        Vector2 halfExtents = new Vector2(width /2f, height/ 2f);

        // Example: Check for collisions with the bird
        GameObject birdObject = GameObject.FindWithTag("BirdTag");
        if (birdObject != null)
        {
            BirdBoundingBox birdCollider = birdObject.GetComponent<BirdBoundingBox>();
            if (birdCollider != null && CheckOverlap(currentPosition, halfExtents, birdObject.transform.position, birdCollider.width, birdCollider.height))
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
        float combinedHeight = (sizeA.y + heightB) / 2f ;

        return distanceX < combinedWidth && distanceY < combinedHeight;
    }

    void HandleCollision()
    {
        // Handle the collision
        Debug.Log("Ground Collision detected!");
        // Add your logic for what happens when a collision is detected
    }

    // Visualize the bounding box in the Scene view
    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 1f));
    }
}