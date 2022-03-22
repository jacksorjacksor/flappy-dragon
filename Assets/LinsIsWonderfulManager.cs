using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinsIsWonderfulManager : MonoBehaviour
{
    public float leftDirection = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(leftDirection, 0f, 0f);
        }
    }
}
