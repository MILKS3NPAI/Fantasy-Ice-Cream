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
    public GameObject music;
    public Text endText;
    public Text timeText;
    public Text buttonText;
    public Image endImage;
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
            //music.GetComponent<AudioSource>().Stop();
 
            spawner.GetComponent<Customer_Spawner>().spawn = false;
            if (score < 200)
            {
                lossScreen.SetActive(true);
                if (!gameEnd)
                {
                    GetComponents<AudioSource>().ElementAt(0).Play();
                    gameEnd = true;
                }
                if (Difficulty.difficulty == 2)
                {
                    buttonText.text = "Accept Death";
                    endImage.GetComponent<Image>().color = new Color(64/255f, 0f, 0f, 1f);
                    endText.GetComponent<Text>().color = new Color(1f, 1f, 0f, 1f);
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
                if (Difficulty.difficulty == 2)
                {
                    endImage.GetComponent<Image>().color = new Color(222/255f, 1f, 1f, 1f);
                    endText.GetComponent<Text>().color = new Color(0f, 128/255f, 1f, 1f);
                }
            }
        }
       
    }
    public void returnToMain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
