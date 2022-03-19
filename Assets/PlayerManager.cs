using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float velocity;
    private Rigidbody2D rb;
    public GameManager gameManager;
    public SpriteRenderer spriteRenderer;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();    
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {   
        // RESIZING
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.velocity = Vector2.up * velocity;
            transform.localScale = new Vector3(0.8f, 1.2f, transform.localScale.z);
        } 
        if (Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.W)|| Input.GetKeyUp(KeyCode.UpArrow))
        {
            transform.localScale = new Vector3(1f, 1f, transform.localScale.z);
        }

        // Down arrow
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            rb.velocity = Vector2.down * velocity * 1f;
            transform.localScale = new Vector3(1.2f,0.8f, transform.localScale.z); 
        }
        // Down arrow
        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
        {
            transform.localScale = new Vector3(1f, 1f, transform.localScale.z);
        }


        // Close to out of bounds
        if (transform.position.y > 2f || transform.position.y < -2f)
        {
            spriteRenderer.color = Color.red;    
        } else
        {
            spriteRenderer.color = Color.white;
        }


        // Out Of Bounds
        if (transform.position.y>2.8f || transform.position.y<-2.5f)
        {
            gameManager.EndOfGame();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameManager.EndOfGame();     
    }
}
