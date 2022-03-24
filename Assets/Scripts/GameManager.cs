using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int HighScore;
    public int TargetScore;
    public float startingSpeedOfObstacles;
    public float speedOfObstacles;
    public float distanceTravelled;
    public bool GameStopped;
    public PlayerManager playerManager;
    public GameObject obstacle;
    public TMPro.TextMeshProUGUI UIScore;
    public TMPro.TextMeshProUGUI UIInstructions;
    public TMPro.TextMeshProUGUI UIDistanceTravelled;
    public TMPro.TextMeshProUGUI Timer;
    public StatsManager statsManager;
    //public CreditManager creditManager;

    public float timer;
    public float gameLength = 5f;

    // Start is called before the first frame update
    void Start()
    {
        statsManager = GameObject.FindObjectOfType<StatsManager>(); 
        // creditManager = GameObject.FindObjectOfType<CreditManager>();
        startingSpeedOfObstacles = -2f;
        GameStopped = true;
        Time.timeScale = 0;
        HighScore = 0;
        UIInstructions.text = "Mouse click/Up/W = UP\nDown/S = DOWN FASTER\n<b>Start with SPACE</b>";
        UIScore.text = "Obstacles passed: "+ HighScore.ToString();
        UIDistanceTravelled.text = "Distance travelled: 0";

    }

    private void Update()
    {
        if (timer > 0)
        {
            // Timer: - countdown & display
            timer -= Time.deltaTime;
            Timer.text = "Seconds remaining: " + Mathf.Round(timer).ToString();
        }
        else
        {
            if (!GameStopped)
            {
                EndOfGame();
            }
        }
        if (GameStopped && Input.GetKeyDown(KeyCode.P))
        {
            StartOfGame();         
        }
    }

    public void StartOfGame()
    {
        
        Time.timeScale = 1;
        timer = gameLength;  
        distanceTravelled = 0f;
        speedOfObstacles = startingSpeedOfObstacles;
        
        HighScore = 0;
        UIInstructions.text = "Mouse click/Up/W = UP\nDown/S = DOWN FASTER";
        UIScore.text = HighScore.ToString();
        GameStopped = false;

        // Player manager - reset position, velocity & recolour
        playerManager.transform.position = new Vector3(-2.8f, 1.5f, 0);
        playerManager.spriteRenderer.color = Color.white;
        playerManager.GetComponent<Rigidbody2D>().velocity = Vector2.zero;  

        // Destroy all obstacles
        // - Destroy all children of ObstacleParent
        // https://answers.unity.com/questions/611850/destroy-all-children-of-object.html
        foreach (Transform child in GameObject.Find("ObstacleParent").transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        ObstacleCreator();
    }

    public void ObstacleCreator()
    {
        Instantiate(obstacle);
    }
    public void EndOfGame()
    {
        Time.timeScale = 0;
        Timer.text = "";
        // store distance? stop distance updating?
        GameStopped = true;
        playerManager.spriteRenderer.color = Color.green;
        UIInstructions.text = "GAME OVER!\nPress SPACE to restart";
        statsManager.completedGames++;
        statsManager.UpdateTicketStats((int)distanceTravelled);
    }
}
