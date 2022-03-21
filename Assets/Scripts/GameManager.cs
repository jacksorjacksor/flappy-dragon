using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int HighScore;
    public int TargetScore;
    public float startingSpeedOfObstacles = -2f;
    public float speedOfObstacles;
    public float distanceTravelled;
    public bool GameStopped;
    public PlayerManager playerManager;
    public Obstacle obstacle;
    public TMPro.TextMeshProUGUI UIScore;
    public TMPro.TextMeshProUGUI UIInstructions;
    public TMPro.TextMeshProUGUI UIDistanceTravelled;
    public TMPro.TextMeshProUGUI Timer;

    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        GameStopped = true;
        Time.timeScale = 0;
        HighScore = 0;
        UIInstructions.text = "Mouse click/Up/W = UP\nDown/S = DOWN FASTER\n<b>Start with SPACE</b>";
        UIScore.text = HighScore.ToString();
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            Timer.text = timer.ToString();
        }
        else
        {
            EndOfGame();
        }
        if (GameStopped && Input.GetKeyDown(KeyCode.Space))
        {
            StartOfGame();   
        }
    }

    public void StartOfGame()
    {
        timer = 30f;  
        distanceTravelled = 0f;
        speedOfObstacles = startingSpeedOfObstacles;
        HighScore = 0;
        UIInstructions.text = "Mouse click/Up/W = UP\nDown/S = DOWN FASTER";
        UIScore.text = HighScore.ToString();
        Time.timeScale = 1;
        GameStopped = false;
        playerManager.spriteRenderer.color = Color.white;
        playerManager.transform.position = new Vector3(-2.8f, 1.5f, 0);
        // Destroy all obstacles
        ObstacleCreator();
    }

    public void ObstacleCreator()
    {
        Instantiate(obstacle);
    }
    public void EndOfGame()
    {
        Time.timeScale = 0;
        Timer.text.Equals("");
        GameStopped = true;
        if (HighScore >= TargetScore)
        {
            playerManager.spriteRenderer.color = Color.green;
            UIInstructions.text = "YOU WIN!\nPress SPACE to restart";
        }
        else
        {
            UIInstructions.text = "YOU LOST!\nPress SPACE to restart";
        }
    }
}
