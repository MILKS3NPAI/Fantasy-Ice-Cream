using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MainMenu : MonoBehaviour
{
    private void Awake()
    {
        DOTween.Init(true, true, LogBehaviour.Default);
    }
    public void playClick()
    {
        DOTween.To(()=> transform.localScale, x=> transform.localScale = x, new Vector3(0, 0, 0), 0.75f);
        Invoke("playGame", 0.75f);
    }

    public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void exitGame()
    {
        Debug.Log("Quitting game");
        Application.Quit();
    }
}
