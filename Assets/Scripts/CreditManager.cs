using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditManager : MonoBehaviour
{
    public int creditCounter = 0;
    TMPro.TextMeshProUGUI creditDisplay;
    StatsManager statsManager;
    bool readyToPlay;

    // Keep active between scenes
    // https://stackoverflow.com/questions/32306704/how-to-pass-data-and-references-between-scenes-in-unity
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    void Start()
    {
        creditDisplay = GameObject.Find("CreditDisplay").GetComponent<TMPro.TextMeshProUGUI>();
        statsManager = GameObject.Find("StatsManager").GetComponent<StatsManager>();
        creditCounterUpdate();
    }

    void Update()
    {   
        // ADDS CREDIT
        if (Input.GetKeyDown(KeyCode.O))
        {
            addCredit();
        }
        // USES CREDIT
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (creditCounter > 0)
            {
                if (!readyToPlay)
                {
                    useCredit();
                }
            }
            else
            {
                // Text should flash red
            }
        }
    }
    public void useCredit()
    {
        creditCounter--;
        creditCounterUpdate();
        statsManager.creditsConsumed++;
        readyToPlay = false;
        // FindObjectOfType<SceneController>().Scene01Load();

    }

    public void addCredit()
    {
        creditCounter++;
        creditCounterUpdate();
        // If current scene isn't 02_gameplay change to that scene. I think?
        // Or have a pre-game scene - fading from black comic book style?
    }


    public void creditCounterUpdate()
    {
        creditDisplay.text = "Credits " + creditCounter.ToString();
    }

}
