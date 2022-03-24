using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameManager gameManager;
    public Vector3 startLocation;
    public Rigidbody2D rbObstacle;

    private void Start()
    {

        rbObstacle = GetComponent<Rigidbody2D>();
        rbObstacle.velocity = Vector2.zero;
        gameManager = FindObjectOfType<GameManager>();
        startLocation = new Vector3(3.8f, Random.Range(-1f, 1f), 0);
        transform.position = startLocation;
        transform.localScale = new Vector3(transform.localScale.x, Random.Range(1f, 3f), transform.localScale.y);
        // Create as child https://answers.unity.com/questions/260100/instantiate-as-a-child-of-the-parent.html
        transform.parent = GameObject.Find("ObstacleParent").transform;
    }

    private void Update()
    {
        if (!gameManager.GameStopped)
        {
            // Move the object based on speedOfObstacles
            transform.position += new Vector3(gameManager.speedOfObstacles * Time.deltaTime, 0f, 0f);

            // Record distance and update
            gameManager.distanceTravelled += Vector2.Distance(new Vector2(transform.position.x, 0), new Vector2(startLocation.x, 0));
            gameManager.UIDistanceTravelled.text = "Distance travelled: " + Mathf.Round(gameManager.distanceTravelled).ToString();
        }
        if (transform.position.x < -3.8f || transform.position.y > 2f || transform.position.y < -2f || transform.position.x > 4.8f)
        {
            ScoreUpdaterAndSpawner();
        }
    }

    private void OnTriggerEnter2D(Collider2D fireball)
    {
        if (fireball.CompareTag("fireball"))
        {
            Destroy(fireball.gameObject);
            ScoreUpdaterAndSpawner();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if an obstacle gets hit, add gravity
        if (Random.Range(0, 2) == 0)
        {
            rbObstacle.gravityScale = -1f;
        }
        else
        {
            rbObstacle.gravityScale = 1f;
        }

        // Speed change on collision
        // When hit, reduce the speed UNLESS it's already 
        if (gameManager.speedOfObstacles < gameManager.startingSpeedOfObstacles)
        {
            gameManager.speedOfObstacles += 0.25f;
        }
        else
        {
            gameManager.speedOfObstacles = gameManager.startingSpeedOfObstacles;
        }
    }
    private void ScoreUpdaterAndSpawner()
    {
        gameManager.HighScore += 1;
        gameManager.UIScore.text = "Obstacles passed: " + gameManager.HighScore.ToString();
        gameManager.speedOfObstacles -= 0.25f;
        gameManager.ObstacleCreator();
        Destroy(gameObject);
    }
}
