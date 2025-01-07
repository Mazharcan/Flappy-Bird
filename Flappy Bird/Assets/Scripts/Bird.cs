using UnityEngine;
using UnityEngine.EventSystems;

public class Bird : MonoBehaviour
{

    public bool isDead;

    public Rigidbody2D rb;

    public float velocity;
    public float lerpSpeed;

    public GameManager managerGame;

    public GameObject DeathScreen;
    public GameObject StartScreen;
    public GameObject ScoreScreen;

    public GameManager gameManagerScripts;

    void Start()
    {
        Time.timeScale = 1;
        ScoreScreen.SetActive(false);
    }

    private void Update()
    {
        // Check for mouse click input
        if (Input.GetMouseButtonDown(0) && !isDead)
        {
            // Make the bird jump
            rb.linearVelocity = Vector2.up * velocity;
            StartScreen.SetActive(false);
            ScoreScreen.SetActive(true);
            rb.bodyType = RigidbodyType2D.Dynamic;
        }

        if (rb.linearVelocity.y > 0)
        {
            // Tilt the bird upwards while jumping
            float targetAngle = 45f; // Target angle
            float currentAngle = transform.rotation.eulerAngles.z; // Current angle of the bird

            transform.rotation = Quaternion.Euler(0, 0, Mathf.LerpAngle(currentAngle, targetAngle, lerpSpeed * Time.deltaTime));  // Smoothly transition the angle to the target angle with lerpSpeed
        }
        else if (rb.linearVelocity.y < 0)
        {
            // Tilt the bird downwards when falling
            float targetAngle = -90f; 
            float currentAngle = transform.rotation.eulerAngles.z; 

            transform.rotation = Quaternion.Euler(0, 0, Mathf.LerpAngle(currentAngle, targetAngle, (lerpSpeed / 5f) * Time.deltaTime));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "ScoreArea")
        {
            managerGame.UpdateScore();   // Update the score when the bird hits the score area
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DeathArea")
        {
            isDead = true;
            Time.timeScale = 0;

            // Hide the score text
            managerGame.scoreText.gameObject.SetActive(false);

            DeathScreen.SetActive(true); // Show the death screen
            managerGame.CheckHighScore();
            managerGame.scoreTextTable.text = managerGame.score.ToString();  // Display the score on the death screen
            managerGame.highScoreTextTable.text = managerGame.highScore.ToString();  // Display the high score on the death screen
        }
    }

}
