using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public int score;
    public int highScore;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreTextTable;
    public TextMeshProUGUI highScoreTextTable;

    public GameObject bronzeMedal; // Bronz madalya GameObject
    public GameObject silverMedal; // Gümüþ madalya GameObject
    public GameObject goldMedal;   // Altýn madalya GameObject

    private void Start()
    {
        score = 0;
        scoreText.text = score.ToString(); //Display the score in the UI

        // Load the high score from PlayerPrefs
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreTextTable.text = highScore.ToString();


        bronzeMedal.SetActive(false);
        silverMedal.SetActive(false);
        goldMedal.SetActive(false);
    }
  
    public void UpdateScore()
    {
        score++; // Increase the score
        scoreText.text = score.ToString(); //Update the score in the UI
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void CheckHighScore()
    {
        if (score > highScore)
        {
            highScore = score; //Set the new high score
            PlayerPrefs.SetInt("HighScore", highScore);  // Save the new high score
        }
        // Medal conditions
        if (score >= 30) 
        {
            goldMedal.SetActive(true);
        }
        else if (score >= 15 && score < 30) 
        {
            silverMedal.SetActive(true);
        }
        else if (score >= 5 && score < 15) 
        {
            bronzeMedal.SetActive(true);
        }
    }
}
