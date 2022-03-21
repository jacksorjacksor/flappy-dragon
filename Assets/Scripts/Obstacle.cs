using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameManager gameManager;
    public Vector3 startLocation;
    public Rigidbody2D rbObstacle;

    private void Start()
    {
        rbObstacle = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();
        startLocation = new Vector3(3.8f, Random.Range(-1f, 1f), 0);
        transform.position = startLocation;
        transform.localScale = new Vector3(transform.localScale.x, Random.Range(1f, 3f), transform.localScale.y);
    }

    private void Update()
    {
        gameManager.distanceTravelled+=Vector2.Distance(new Vector2(transform.position.x, 0), new Vector2(startLocation.x,0));
        gameManager.UIDistanceTravelled.text = gameManager.distanceTravelled.ToString();    
        transform.position += new Vector3 (gameManager.speedOfObstacles * Time.deltaTime, 0f, 0f);


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
        rbObstacle.gravityScale = 1f;
        if (gameManager.speedOfObstacles.Equals(gameManager.startingSpeedOfObstacles))
        {
            gameManager.speedOfObstacles = gameManager.startingSpeedOfObstacles;
        } else
        {
            gameManager.speedOfObstacles *= 1.1f; ;
        }
    }
    private void ScoreUpdaterAndSpawner()
    {
        gameManager.HighScore += 1;
        gameManager.UIScore.text = gameManager.HighScore.ToString() + "/" + gameManager.TargetScore.ToString();
        if(gameManager.speedOfObstacles > 0)
        {
            gameManager.speedOfObstacles *= -1;  
        }    
        gameManager.speedOfObstacles *= 1.1f;
        gameManager.ObstacleCreator();
        Destroy(gameObject);
    }
}
