using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PatienceScript : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SetMaxPatience(int patience)
    {
        slider.maxValue = patience;
        slider.value = patience;

        gradient.Evaluate(1f);
    }

    public void SetPatience(float patience)
    {
        slider.value = patience;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
