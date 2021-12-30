using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

  //ambil slider
  public Slider slider;

  public Gradient gradient;
  public Image fill;


  // function for setting max value health
  public void SetMaxHealth(int health) {

    slider.maxValue = health;
    slider.value = health;
    fill.color = gradient.Evaluate(1f);
  }

  // function setting slider
  public void SetHealth(int health) {

    slider.value = health;

    fill.color = gradient.Evaluate(slider.normalizedValue);
  }
}
