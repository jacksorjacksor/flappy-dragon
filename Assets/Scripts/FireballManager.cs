using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("FIRE!");
        GetComponent<Rigidbody2D>().velocity = Vector2.right * 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x>=3f)
        {
            Destroy(gameObject);
        } 
    }
}
