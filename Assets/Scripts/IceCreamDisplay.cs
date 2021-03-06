﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IceCreamDisplay : MonoBehaviour
{
    public GameObject display;
    //Cone
    public GameObject ConeBox;
    public GameObject cone;
    public bool conePresent = false;
    //display ice cream
    public GameObject van;
    public GameObject choco;
    public GameObject straw;
    //Ice cream boxes
    public GameObject IB1;
    public GameObject IB2;
    public GameObject IB3;
    //others
    public List<int> currentOrder = new List<int>();
    FlavorValue FV;
    enum FlavorValue {Vanilla = 1, Chocolate, Strawberry};
    public int stack = 0;
    public AudioSource coneAudio;
    public AudioSource holyVanillaAudio;
    public AudioSource midnightChocolateAudio;
    public AudioSource strawBerryAudio;

    private void Start()
    {

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && stack < 4 && conePresent == true)
        {
            GetIceCream();

        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Clear();
        }

        if (Input.GetKeyDown(KeyCode.Space) && (ConeBox.GetComponent<ConeBox>().playerInRange == true) && stack == 0)
        {
            GetCone();
        }
    }

    private void GetCone()
    {
        if (conePresent == false)
        {
            ConeBox.GetComponent<ConeBox>().dialogbox.SetActive(true);
            ConeBox.GetComponent<ConeBox>().dialogText.text = "You Got Cone";
            cone = Instantiate(cone, new Vector3(0, 0, 0), Quaternion.identity);
            cone.transform.SetParent(transform, false);
            cone.transform.localPosition = new Vector2(0, -190);
            cone.SetActive(true);
            conePresent = true;
            coneAudio.Play();
        }

        else if (conePresent == true)
        {
            ConeBox.GetComponent<ConeBox>().dialogbox.SetActive(true);
            ConeBox.GetComponent<ConeBox>().dialogText.text = "You already have a Cone";
        }
    }

    private void GetIceCream()
    {
        if (IB1.GetComponent<IceCreamBox>().playerInRange == true)
        {
            FV = FlavorValue.Vanilla;
            Scoop(van);
            holyVanillaAudio.Play();
        }
        else if (IB2.GetComponent<IceCreamBox>().playerInRange == true)
        {
            FV = FlavorValue.Chocolate;
            Scoop(choco);
            midnightChocolateAudio.Play();
        }
        else if (IB3.GetComponent<IceCreamBox>().playerInRange == true)
        {
            FV = FlavorValue.Strawberry;
            Scoop(straw);
            strawBerryAudio.Play();
        }
    }

    void Scoop(GameObject x)
    {
        x = Instantiate(x, new Vector2(0, 0), Quaternion.identity);
        x.transform.SetParent(transform, false);
        x.SetActive(true);
        x.transform.localPosition = new Vector2(0, (-90 + (80 * stack)));
        x.GetComponent<Image>().rectTransform.sizeDelta = new Vector2(150, 150);
        stack++;
        currentOrder.Add((int)FV);
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
        currentOrder.Clear();
        conePresent = false;
    }
}
