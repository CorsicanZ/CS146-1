using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitCircleSlider : MonoBehaviour
{
    public Slider circle_slider;
    // Update is called once per frame
    public void set_value(int max_value) 
    {
        circle_slider.maxValue = max_value;
        circle_slider.value = max_value;
    }

    public void value_min() 
    {
        if (circle_slider.value == 0) return;
        circle_slider.value -= 1;
    }

    public void value_plus() 
    {
        if (circle_slider.value == circle_slider.maxValue) return;
        circle_slider.value += 1;
    }
}