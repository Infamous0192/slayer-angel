using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScreen : MonoBehaviour {
  public void BackToBase() {
    Time.timeScale = 1;
    SceneManager.LoadScene("Starship");
  }
}
