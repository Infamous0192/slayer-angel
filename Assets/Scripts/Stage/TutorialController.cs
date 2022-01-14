using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialController : MonoBehaviour {

  public GameObject promptTutor;
  public GameObject promptTutor2;

  // Start is called before the first frame update
  void Start() {
    if (PlayerPrefs.GetInt("FIRSTTIMEOPENING", 1) == 1) {
      Debug.Log("First Time Opening");

      //Set first time opening to false
      PlayerPrefs.SetInt("FIRSTTIMEOPENING", 0);

      //Do your stuff here
      Time.timeScale = 0;
      promptTutor.SetActive(true);

      // } else {
      //   Debug.Log("NOT First Time Opening");

      //   //Do your stuff here
    }
  }

  // Update is called once per frame
  void Update() {

  }


  public void BacktoGame() {
    Time.timeScale = 1;
    promptTutor2.SetActive(false);
  }
}
