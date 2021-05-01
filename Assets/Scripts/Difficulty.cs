using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Difficulty : MonoBehaviour
{
    public static int difficulty;
    public GameObject notification;

    public void easyDifficulty()
    {
        notification.GetComponent<Text>().text = "You selected Normal";
        difficulty = 1;
        StartCoroutine(Wait());
    }
    public void hardDifficulty()
    {
        notification.GetComponent<Text>().text = "You selected Nightmare...";
        difficulty = 2;
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        notification.SetActive(true);
        yield return new WaitForSeconds(2);
        notification.SetActive(false);
    }
}
