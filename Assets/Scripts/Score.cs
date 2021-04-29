using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public float gScore;
    private void Start()
    {
        CustomerAI.score *= 0;
        scoreText.text = "$0.00";
    }

    // Update is called once per frame
    void Update()
    {
        gScore += CustomerAI.score;
        scoreText.text = "$" + CustomerAI.score.ToString("F2");
    }
}
