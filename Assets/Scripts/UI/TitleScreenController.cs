using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScreenController : MonoBehaviour {

  public Button btnPlay;
  public Button btnQuit;
  public Button btnVolume;
  public Button btnBackToGame;

  public GameObject promptVolume;

  // Start is called before the first frame update
  void Start() {
    btnPlay.onClick.AddListener(() => {
      SceneManager.LoadScene(1);
    });
    btnVolume.onClick.AddListener(() => {
      promptVolume.SetActive(true);
    });
    btnBackToGame.onClick.AddListener(() => {
      promptVolume.SetActive(false);
    });

    btnQuit.onClick.AddListener(() => {
#if !UNITY_EDITOR
                Application.Quit();
#endif
#if UNITY_EDITOR
      UnityEditor.EditorApplication.isPlaying = false;
#endif
    });

  }



  // Update is called once per frame
  void Update() {

  }
}
