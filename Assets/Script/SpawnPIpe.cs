using UnityEngine;

public class SpawnPIpe : MonoBehaviour
{
    public float maxTime = 1;
    private float timer = 0;
    public GameObject pipe;
    public float height;

    // Start is called before the first frame update
    void Start()
    {
        SpawnNewPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > maxTime)
        {
            SpawnNewPipe();
            timer = 0;
        }

        timer += Time.deltaTime;
    }

    void SpawnNewPipe()
    {
        GameObject newPipe = Instantiate(pipe);
        newPipe.transform.position = transform.position + Vector3.up * Random.Range(-height, height);
        Destroy(newPipe, 15);
    }
}