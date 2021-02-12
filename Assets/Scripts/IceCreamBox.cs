﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IceCreamBox : MonoBehaviour
{
    public GameObject ICDisplay;
    public GameObject dialogbox;
    public Text dialogText;
    public string dialog;
    public bool playerInRange;
   

    // Start is called before the first frame update
    void Start()
    {
        ICDisplay = GameObject.FindGameObjectWithTag("IceCreamDisplay");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            if (ICDisplay.GetComponent<IceCreamDisplay>().conePresent == true)
            {
                dialogbox.SetActive(true);
                dialogText.text = dialog;
            }
       

            else if (ICDisplay.GetComponent<IceCreamDisplay>().conePresent == false)
            {
                dialogbox.SetActive(true);
                dialogText.text = "Get Cone First";
            }
        }
       
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
