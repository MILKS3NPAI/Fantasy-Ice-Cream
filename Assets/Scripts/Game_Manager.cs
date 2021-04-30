using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    public Text buttonText;
    float score;
    float timeLimit;
    GameObject lossScreen;
    private bool gameEnd;
    
    // Start is called before the first frame update
    void Start()
    {
        gameEnd = false;
        timeLimit = 120;
        
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
            score = s.GetComponent<Score>().gScore;
 
            spawner.GetComponent<Customer_Spawner>().spawn = false;
            if (score < 200)
            {
                lossScreen.SetActive(true);
                if (!gameEnd)
                {
                    GetComponents<AudioSource>().ElementAt(0).Play();
                    gameEnd = true;
                }
            }
            else
            {
                endText.text = "You paid your Debt for today";
                buttonText.text = "Hooray!";
                lossScreen.SetActive(true);
                if (!gameEnd)
                {
                    GetComponents<AudioSource>().ElementAt(1).Play();
                    gameEnd = true;
                }
            }
        }
       
    }
    public void returnToMain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
