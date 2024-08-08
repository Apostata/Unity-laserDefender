using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TMPro.TextMeshProUGUI scoreText;
    [SerializeField] Slider healthSlider;

   

   public void InitializeSlider(float maxHealth, float minHealth)
   {
       healthSlider.maxValue = maxHealth;
        healthSlider.minValue = minHealth;
       healthSlider.value = maxHealth;
   }
   public void UpdateScore(int score)
   {
       scoreText.text = score.ToString().PadLeft(8, '0');
   }

    public void UpdateHealth(float health)
    {
        healthSlider.value = health;
    }
}
