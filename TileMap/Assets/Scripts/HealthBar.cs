using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Made after: https://yewtu.be/watch?v=BLfNP4Sc_iA
    
public class HealthBar : MonoBehaviour
{
    public Slider slider;
    

    public void SetHealth(float health) { 
        slider.value = health;
    }
}