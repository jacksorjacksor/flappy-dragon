using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditManager : MonoBehaviour
{
    public int creditCounter = 0;

    // Keep active between scenes
    // https://stackoverflow.com/questions/32306704/how-to-pass-data-and-references-between-scenes-in-unity
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
