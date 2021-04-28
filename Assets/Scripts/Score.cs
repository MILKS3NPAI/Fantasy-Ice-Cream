using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    private void Start()
    {
        CustomerAI.score *= 0;
        scoreText.text = "$0.00";
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "$" + CustomerAI.score.ToString("F2");
    }
}
