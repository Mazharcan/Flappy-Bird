using System.Collections;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public Bird birdScripts;
    public GameObject pipes;
    public float height;        // Height range for spawning pipes
    public float time;          // Time interval between each spawn 

    private bool isGameStarted = false; // Controls whether the spawn process has started

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isGameStarted)
        {
            isGameStarted = true; // Start the spawning process
            StartCoroutine(SpawnObject(time)); // Start the Coroutine to spawn pipes
        }
    }

    public IEnumerator SpawnObject(float time)
    {
        while (time > 0)
        {
            // Instantiate pipes at a random height within the range
            Instantiate(pipes, new Vector3(3.5f, Random.Range(-height - 0.3f, height), 0), Quaternion.identity);
            yield return new WaitForSeconds(time); // Wait for the specified time interval
        }
    }
}
