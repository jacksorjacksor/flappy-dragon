using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    // Stats to be recorded:
    // Total runtime
    public float totalRuntime;
    // Total credits consumed
    public int creditsConsumed = 0;
    // Total completed games (++ on game over)
    public int completedGames = 0;
    // TODO: Average playtime
    public float averagePlaytime = 0; // Always???
    // TODO: Total tickets distributed
    public int totalTicketsDistributed = 0;
    // TODO: Lowest tickets
    public int lowestTicketsDistributed = 0;
    // TODO: Highest tickets
    public int highestTicketsDistributed = 0;
    public List<int> listOfTickets = new List<int>();

    private void Awake()
    {
        DontDestroyOnLoad(this);
        totalRuntime = Time.realtimeSinceStartup; // This needs to be called WHEN the options menu is loaded
    }

    public void UpdateTicketStats(int NumberOfTickets)
    {
        // Add ticket to list
        listOfTickets.Add(NumberOfTickets);

        totalTicketsDistributed = 0;
        lowestTicketsDistributed = 0;
        highestTicketsDistributed = 0;
        foreach (int ticket in listOfTickets)
        {
            // Sum of list
            totalTicketsDistributed += ticket;

            // Lowest of list
            if (lowestTicketsDistributed.Equals(0))
            {
                lowestTicketsDistributed = ticket;
            } else
            {
                if (ticket < lowestTicketsDistributed)
                {
                    lowestTicketsDistributed = ticket;
                }
            }

            // Highests of list
            if (highestTicketsDistributed.Equals(0))
            {
                highestTicketsDistributed = ticket;
            }
            else
            {
                if (ticket > highestTicketsDistributed)
                {
                    highestTicketsDistributed = ticket;
                }
            }
        }
        Debug.Log("Distance Totals: cur = "+NumberOfTickets +" | total = " + totalTicketsDistributed + " | min =" + lowestTicketsDistributed + " | max =" + highestTicketsDistributed);
    }
}
