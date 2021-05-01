using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Difficulty : MonoBehaviour
{
    public static int difficulty;
    public GameObject dialogbox;
    public void easyDifficulty()
    {
        difficulty = 1;
        dialogbox.GetComponent<Text>().text = "You selected Normal";
        StartCoroutine(MyCoroutine());
    }
    public void hardDifficulty()
    {
        difficulty = 2;
        dialogbox.GetComponent<Text>().text = "You selected Nightmare...";
        StartCoroutine(MyCoroutine());
    }

    IEnumerator MyCoroutine()
    {
        dialogbox.SetActive(true);
        yield return new WaitForSeconds(2);
        dialogbox.SetActive(false);
    }
}
