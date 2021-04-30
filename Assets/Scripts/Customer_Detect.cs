using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer_Detect : MonoBehaviour
{
    public bool customerInRange = false;
    float customers = 0;

    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Customer") && customerInRange == false)
        {
            customerInRange = true;
  
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Customer"))
        {
            customerInRange = false;
        }
    }
}
