using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditScreen : MonoBehaviour {
  bool loadingStarted = false;
  float secondsLeft = 0;

  void Start() {
    StartCoroutine(DelayLoadLevel(5));
  }

  IEnumerator DelayLoadLevel(float seconds) {
    secondsLeft = seconds;
    loadingStarted = true;
    do {
      yield return new WaitForSeconds(1);
    } while (--secondsLeft > 0);

    Application.LoadLevel("TitleScreen");
  }
}
