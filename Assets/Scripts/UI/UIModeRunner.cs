using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIModeRunner : MonoBehaviour {

  // Inisialisasi dan ambil button Back to Starship
  public Button btnBackStarship;


  public GameObject promptExit; // inisialisasi ambil panel prompt Exit
  public GameObject promptOption; // inisialisasi ambil panel prompt Option

  public Button btnCancelBackSs; // inisialisai ambil btnNo

  public Button btnVolume; // inisialisai ambil btn Option

  public Button btnBackToGame; // inisialisasi ambil Button Back to Game


  // Start is called before the first frame update
  void Start() {
    btnBackStarship.onClick.AddListener(() => {
      promptExit.SetActive(true);
    });

    btnCancelBackSs.onClick.AddListener(() => {
      promptExit.SetActive(false);
    });

    btnBackToGame.onClick.AddListener(() => {
      promptOption.SetActive(false);
    });

    btnVolume.onClick.AddListener(() => {
      promptOption.SetActive(true);
    });
  }

  // Update is called once per frame
  void Update() {

  }
}
