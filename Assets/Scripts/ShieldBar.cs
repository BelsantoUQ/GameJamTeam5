using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldBar : MonoBehaviour
{

    [SerializeField] public Slider slider;


    public void SetMaxShield(int maxShield)
    {
        slider.maxValue = maxShield;
        
    }


    public void SetShield(int shield)
    {
        if (shield > slider.maxValue)
        {
            slider.value = slider.maxValue;

        } else
        {
            slider.value = shield;
        }
    }




}
