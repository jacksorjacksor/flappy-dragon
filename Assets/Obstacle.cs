using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameManager gameManager;

    
 
    private void Update()
    {
        transform.position += new Vector3 (gameManager.speedOfObstacles * Time.deltaTime, 0f, 0f);
        if (transform.position.x<-3.8f)
        {
            gameManager.HighScore += 1;
            gameManager.UIScore.text = gameManager.HighScore.ToString() + "/" + gameManager.TargetScore.ToString();
            gameManager.speedOfObstacles *= 1.1f;

            if (gameManager.HighScore>=gameManager.TargetScore)
            {
                gameManager.EndOfGame();
            }
            transform.position = new Vector3(3.8f, Random.Range(-1f, 1f), 0);
            transform.localScale = new Vector3(transform.localScale.x, Random.Range(1f, 3f), transform.localScale.y);
        }
    }
}
