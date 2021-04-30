using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour
{
    [SerializeField]
    public GameObject s;
    public GameObject spawner;
    public Text endText;
    public Text timeText;
    float score;
    float timeLimit;
    GameObject lossScreen;
    
    // Start is called before the first frame update
    void Start()
    {
        timeLimit = 120;
        score = s.GetComponent<Score>().gScore;
        lossScreen = GameObject.FindGameObjectWithTag("Lose");
        lossScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timeLimit -= Time.deltaTime;
        timeText.text = "Time Left: " + timeLimit.ToString("0");
        if (timeLimit <= 0)
        {
            spawner.GetComponent<Customer_Spawner>().spawn = false;
            if (score < 200)
            {
                lossScreen.SetActive(true); 
            }
            else
            {
                endText.text = "You paid your Debt for today";
                lossScreen.SetActive(true);

            }
        }
       
    }
}
