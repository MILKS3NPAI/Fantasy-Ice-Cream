using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class CustomerAI : MonoBehaviour
{
    GameObject playerIC;
    public GameObject dialogbox;
    public Text dialogText;
    bool playerInRange;
    //lists
    public List<int> myOrder = new List<int>();
    public List<int> playerOrder = new List<int>();

    
    void Start()
    {
        playerIC = GameObject.FindGameObjectWithTag("IceCreamDisplay");
        //dialogbox = GameObject.Find("IceCream Notif");
        myOrder.Add(1);
        myOrder.Add(2);
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            playerOrder = playerIC.GetComponent<IceCreamDisplay>().currentOrder;
            if (playerOrder.SequenceEqual(myOrder) == true)
            {
                dialogbox.SetActive(true);
                dialogText.text = "Thank You!";
                playerIC.GetComponent<IceCreamDisplay>().Clear();
            }

            else
            {
                dialogbox.SetActive(true);
                dialogText.text = "wtf";
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

    bool CheckOrder(List<int> x, List<int> y)
    {
        int i =  0;
        foreach (int z in x)
        {
            if (z != y[i])
                return false;
            i++;
        }
        return true;
    }

}
