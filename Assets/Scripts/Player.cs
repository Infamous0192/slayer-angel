using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
  public float MovementSpeed = 1f;
  public KeyCode RightButton = KeyCode.RightArrow;
  public KeyCode LeftButton = KeyCode.LeftArrow;
  public KeyCode SpaceButton = KeyCode.Space;

  // HealhBar
  public int maxHealth = 100;
  public int currentHealth;
  public HealthBar healthBar;



  // Start is called before the first frame update
  void Start() {
    currentHealth = maxHealth;
    healthBar.SetMaxHealth(maxHealth);
  }

  // Update is called once per frame
  void Update() {
    if (Input.GetKey(RightButton)) {
      MovementSpeed += 0.2f;
    }

    if (Input.GetKey(LeftButton)) {
      MovementSpeed -= 0.2f;
    }

    if (Input.GetKeyDown(SpaceButton)) {

      TakeDamage(20);
    }
  }

  void TakeDamage(int damage) {
    currentHealth -= damage;
    healthBar.SetHealth(currentHealth);
  }
}
