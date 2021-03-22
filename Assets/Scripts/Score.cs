using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public float score;
    public Text scoreText;
    public CustomerAI customer;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (customer.orderDone)
        {
            increaseScore();
        }
        scoreText.text = "$" + score.ToString("F2");
    }

    public void increaseScore()
    {
        // Calculation for score, based on number of scoops and how long the order was completed
        score += customer.myOrder.Count * Mathf.Sqrt(customer.currentPatience) * 0.5f;

        // Prevents score from being added again
        customer.currentPatience = 0;
    }
}
