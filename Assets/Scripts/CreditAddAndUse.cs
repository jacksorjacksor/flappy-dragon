using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditAddAndUse : MonoBehaviour
{
    // Start is called before the first frame update
    CreditManager creditManager;
    void Start()
    {
        creditManager = GameObject.Find("CreditManager").GetComponent<CreditManager>();
        creditCounterUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            creditManager.creditCounter++;
            creditCounterUpdate();
        }
        if (Input.GetKeyDown(KeyCode.Space) )
        {
            if (creditManager.creditCounter >= 0)
            {
                creditManager.creditCounter--;
                creditCounterUpdate();
                FindObjectOfType<SceneController>().Scene01Load();

            }
            else
            {
                // Text should flash red
            }
        }
    }
    public void creditCounterUpdate()
    {
        gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "Credits " + creditManager.creditCounter.ToString();
    }
}
