using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour {

  public Slider Slider;
  public Color High;
  public Color Low;
  public Vector3 offset;


  public void SetHealth(int health, int maxHealth) {

    Slider.gameObject.SetActive(health < maxHealth);
    Slider.value = health;
    Slider.maxValue = maxHealth;

    Slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(Low, High, Slider.normalizedValue);
  }

  // Update is called once per frame
  void Update() {
    Slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
  }
}
