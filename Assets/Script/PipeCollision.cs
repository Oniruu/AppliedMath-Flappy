using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeCollision : MonoBehaviour
{
    private void Update()
    {
        // Check for collisions with the bird
        CheckBirdCollision();
    }

    private void CheckBirdCollision()
    {
        GameObject bird = GameObject.FindGameObjectWithTag("BirdTag");

        if (bird != null)
        {
            BirdBoundingBox birdCollision = bird.GetComponent<BirdBoundingBox>();

            if (birdCollision != null && CheckOverlap(transform.position, GetHalfExtents(), bird.transform.position, birdCollision.GetHalfExtents()))
            {
                HandleCollision();
            }
        }
    }

    private Vector2 GetHalfExtents()
    {
        // Calculate half extents of the pipe bounding box
        return new Vector2(GetComponent<SpriteRenderer>().bounds.size.x / 2f, GetComponent<SpriteRenderer>().bounds.size.y / 2f);
    }

    private bool CheckOverlap(Vector2 posA, Vector2 sizeA, Vector2 posB, Vector2 sizeB)
    {
        // Check for overlap between two bounding boxes
        return posA.x - sizeA.x < posB.x + sizeB.x &&
               posA.x + sizeA.x > posB.x - sizeB.x &&
               posA.y - sizeA.y < posB.y + sizeB.y &&
               posA.y + sizeA.y > posB.y - sizeB.y;
    }

    private void HandleCollision()
    {
        // Handle collision with the bird (e.g., game over logic)
        Debug.Log("Pipe collided with the bird!");
    }
}