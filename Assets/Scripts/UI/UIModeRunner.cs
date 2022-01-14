using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIModeRunner : MonoBehaviour {

  // Inisialisasi dan ambil button Back to Starship
  public Button btnBackStarship;


  public GameObject promptExit; // inisialisasi ambil panel prompt Exit
  public GameObject promptOption; // inisialisasi ambil panel prompt Option

  public Button btnCancelBackSs; // inisialisai ambil btnNo
  public Button btnBackToSs; // inisialisai ambil btnNo

  public Button btnVolume; // inisialisai ambil btn Option

  public Button btnBackToGame; // inisialisasi ambil Button Back to Game


  // public Slider slider;


  // Start is called before the first frame update
  void Start() {
    btnBackStarship.onClick.AddListener(() => {
      promptExit.SetActive(true);
      promptOption.SetActive(false);
    });

    btnCancelBackSs.onClick.AddListener(() => {
      promptExit.SetActive(false);
    });
    btnBackToSs.onClick.AddListener(() => {
      SceneManager.LoadScene(1);
    });

    btnBackToGame.onClick.AddListener(() => {
      promptOption.SetActive(false);
    });

    btnVolume.onClick.AddListener(() => {
      promptOption.SetActive(true);
      promptExit.SetActive(false);
    });

    GameObject obj = GameObject.FindGameObjectWithTag("music");
    Destroy(obj);

  }


  // public void SetMaxProgress(int progress) {

  //   GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");


  //   slider.maxValue = progress;
  //   slider.value = enemies.Length;

  //   if (enemies.Length == 9) {

  //   }
  // }


  // Update is called once per frame
  void Update() {



  }
}
