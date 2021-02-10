using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCreamDisplay : MonoBehaviour
{
    public GameObject display;
    public GameObject cone;
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
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Clear();
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

    public void Clear()
    {
        int i = 0;

        //Array to hold all child obj
        GameObject[] allChildren = new GameObject[transform.childCount];

        //Find all child obj and store to that array
        foreach (Transform child in transform)
        {
            allChildren[i] = child.gameObject;
            i += 1;
        }

        //Now destroy them
        foreach (GameObject child in allChildren)
        {
            //DestroyImmediate(child.gameObject);
            child.SetActive(false);
        }
        stack = 0;

        cone = Instantiate(cone, new Vector3 (0, 0, 0), Quaternion.identity);
        cone.transform.SetParent(transform, false);
        cone.transform.localPosition = new Vector2(0, -190);
        cone.transform.rotation *= Quaternion.Euler(0, 0, 180);
        cone.SetActive(true);
  
    }
}
