using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConeBox : MonoBehaviour
{
    public GameObject ICDisplay;
    public GameObject dialogbox;
    public Text dialogText;
    public string dialog;
    public bool playerInRange;


    void Start()
    {
        ICDisplay = GameObject.FindGameObjectWithTag("IceCreamDisplay");
    }

    
    void Update()
    {


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            dialogbox.SetActive(false);
        }
    }
}
