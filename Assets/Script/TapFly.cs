using UnityEngine;

public class TapFly : MonoBehaviour
{
    public float velocity = 1;
    private CustomGravity gravityScript;

    void Start()
    {
        gravityScript = GetComponent<CustomGravity>();
        if (gravityScript == null)
        {
            Debug.LogError("CustomGravity script not found on the GameObject.");
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Call the Jump method from the CustomGravity script
            gravityScript.Jump(velocity);
        }
    }
}