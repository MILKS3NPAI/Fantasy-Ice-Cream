using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCreamDisplay : MonoBehaviour
{
    //display ice cream
    public GameObject van;
    public GameObject choco;
    public GameObject straw;
    //Ice cream boxes
    public GameObject IB1;
    public GameObject IB2;
    public GameObject IB3;

    public int stack = 0;
    
    private void Start()
    {

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (IB1.GetComponent<IceCreamBox>().playerInRange == true) && stack < 5)
        {
            scoop(van);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && (IB2.GetComponent<IceCreamBox>().playerInRange == true) && stack < 5)
        {
            scoop(choco);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && (IB3.GetComponent<IceCreamBox>().playerInRange == true) && stack < 5)
        {
            scoop(straw);
        }
    }

    void scoop(GameObject x)
    {
        x = Instantiate(x, new Vector2(0, 0), Quaternion.identity);
        x.transform.SetParent(transform, false);
        x.SetActive(true);
        x.transform.localPosition = new Vector2(0, (-90 + (100 * stack)));
        stack++;
    }
}
