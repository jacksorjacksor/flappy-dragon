using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        transform.position = new Vector3(3.8f, Random.Range(-1f, 1f), 0);
        transform.localScale = new Vector3(transform.localScale.x, Random.Range(1f, 3f), transform.localScale.y);
    }

    private void Update()
    {
        transform.position += new Vector3 (gameManager.speedOfObstacles * Time.deltaTime, 0f, 0f);
        if (transform.position.x < -3.8f)
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
    private void ScoreUpdaterAndSpawner()
    {
        gameManager.HighScore += 1;
        gameManager.UIScore.text = gameManager.HighScore.ToString() + "/" + gameManager.TargetScore.ToString();
        gameManager.ObstacleCreator();
        Destroy(gameObject);
    }
}
