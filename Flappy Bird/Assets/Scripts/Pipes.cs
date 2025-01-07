using UnityEngine;

public class Pipes : MonoBehaviour
{
    public float speed; // Speed at which the pipes move

    private void Start()
    {
        Destroy(gameObject, 6); // Destroy this GameObject after 6 seconds
    }
    private void FixedUpdate()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
