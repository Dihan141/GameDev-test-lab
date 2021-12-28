using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Slider healthSlider;
    public Gradient gradient;
    public Image fill;
    
    public void SetMaxHealth(int health)
    {
        healthSlider.value = health;
        healthSlider.maxValue = health;
        fill.color = gradient.Evaluate(1);
    }
    public void SetHealth(int health)
    {
        healthSlider.value = health;
        fill.color = gradient.Evaluate(healthSlider.normalizedValue);
    }

}
