using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldBar : MonoBehaviour
{

    [SerializeField] public Slider slider;
    //Variable para poder saber la colision con los puntos
    [SerializeField] HudVariables points;
    [SerializeField] private Image bar;
    // Colores a usar para el sidebar
    public Color colorNormal; // Color normal cuando no está al máximo
    public Color colorMax;  

    private void FixedUpdate()
    {
        SetShield();
    }

    public void SetMaxShield(int maxShield)
    {
        slider.maxValue = maxShield;
    }

    public void SetShield()
    {
        var shield = points.shield;

        if (shield >= slider.maxValue)
        {
            slider.value = slider.maxValue;
            bar.color = colorMax; // Cambiar el color al máximo
        }
        else
        {
            slider.value = shield;
            bar.color = colorNormal; // Restaurar el color normal
        }
    }

    public void AddShield()
    {
        if(points.shield <99)
            points.shield += 25;
    }

    public void RemoveShield()
    {
        if (!(points.shield > 99)) return;
        points.shield = 0;
    }
    
    public bool IsShieldReady()
    {
        return points.shield >99;
    }

}
