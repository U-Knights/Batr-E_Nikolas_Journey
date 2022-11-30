using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Made after: https://yewtu.be/watch?v=BLfNP4Sc_iA
    
public class HealthBar : MonoBehaviour
{
    // Get relevant components
    public Slider slider;
    private Image fill;

    private Color[] colors = {new Color32(195,  65, 70, 255),   // Red
                              new Color32(231, 140, 91, 255),   // Orange
                              new Color32(247, 213, 84, 255),   // Yellow
                              new Color32(141, 162, 78, 255) }; // Green

    void Start()
    {
        fill = GameObject.Find("Fill").GetComponent<Image>();
    }

    public void SetHealth(float health) {
        // Calculate relevant values for color index and slider position
        int colorIndex = (int)(health / (100.0 / colors.Length));
        if (colorIndex >= 4) colorIndex = 3; // Avoid Index Overflow
        int rounded = Mathf.RoundToInt(health / slider.maxValue);

        // Apply new values to the components
        slider.value = rounded;
        fill.color = colors[colorIndex];
    }
}
