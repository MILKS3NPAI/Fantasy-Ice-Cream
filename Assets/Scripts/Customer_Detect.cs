using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer_Detect : MonoBehaviour
{
    public bool customerInRange;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Customer"))
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
