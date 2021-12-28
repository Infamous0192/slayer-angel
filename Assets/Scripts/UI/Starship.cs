using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Starship : MonoBehaviour {
  public Button btnTeleport;

  public Button btnExitTeleport;
  public Button btnCharUpgrade;
  public Button btnExitCharUpgrade;

  public Button playStage;
  public GameObject gateTeleport;
  public GameObject charUpgradeMenu;




  void Start() {
    btnTeleport.onClick.AddListener(() => {
      
      gateTeleport.SetActive(true);
    });
    btnExitTeleport.onClick.AddListener(() => {
      gateTeleport.SetActive(false);
    });
    btnCharUpgrade.onClick.AddListener(() => {
      charUpgradeMenu.SetActive(true);
    });
    btnExitCharUpgrade.onClick.AddListener(() => {
      charUpgradeMenu.SetActive(false);
    });
    playStage.onClick.AddListener(() => {
      SceneManager.LoadScene(2);
    });


  }

  // Update is called once per frame
  void Update() {

  }
}
