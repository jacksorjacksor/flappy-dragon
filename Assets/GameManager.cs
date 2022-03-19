using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int HighScore;
    public int TargetScore;
    public float speedOfObstacles;
    bool GameStopped;
    public PlayerManager playerManager;
    public Obstacle obstacle;
    public TMPro.TextMeshProUGUI UIScore;
    public TMPro.TextMeshProUGUI UIInstructions;

    // Start is called before the first frame update
    void Start()
    {
        GameStopped = true;
        Time.timeScale = 0;
        HighScore = 0;
        TargetScore = 10;
        UIInstructions.text = "Mouse click/Up/W = UP\nDown/S = DOWN FASTER\n<b>Start with SPACE</b>";
        UIScore.text = HighScore.ToString() + "/" + TargetScore.ToString();
    }

    private void Update()
    {
        if (GameStopped && Input.GetKeyDown(KeyCode.Space))
        {
            StartOfGame();   
        }
    }

    public void StartOfGame()
    {
        speedOfObstacles = -2f;
        HighScore = 0;
        TargetScore = 10;
        UIInstructions.text = "Mouse click/Up/W = UP\nDown/S = DOWN FASTER";
        UIScore.text = HighScore.ToString() + "/" + TargetScore.ToString();
        Time.timeScale = 1;
        GameStopped = false;
        playerManager.spriteRenderer.color = Color.white;
        playerManager.transform.position = new Vector3(-2.8f, 1.5f, 0);
        obstacle.transform.position = new Vector3(3.8f,-1f,0);
    }

    public void EndOfGame()
    {
        Time.timeScale = 0;
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
