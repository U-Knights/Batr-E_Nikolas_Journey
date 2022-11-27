using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Made after: https://yewtu.be/watch?v=BLfNP4Sc_iA
    
public class HealthBar : MonoBehaviour
{
    // Get relevant components
    public Slider slider;
    public Image fill = GameObject.Find("Fill").GetComponent<Image>();

    private Color[] colors = {new Color32(195,  65, 70, 255),   // Red
                              new Color32(231, 140, 91, 255),   // Orange
                              new Color32(247, 213, 84, 255),   // Yellow
                              new Color32(141, 162, 78, 255) }; // Green

    public void SetHealth(float health) {
        // Calculate relevant values for color index and slider position
        int colorIndex = (int) (health / (100.0 / colors.Length));
        int rounded = Mathf.RoundToInt(health / slider.maxValue);

        // Apply new values to the components
        slider.value = rounded;
        fill.color = colors[colorIndex];
    }
}