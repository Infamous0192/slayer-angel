using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUpgradeChar : MonoBehaviour {


  public Button btnEquipment;

  public Button btnSkiil;

  public GameObject kontenEquip;
  public GameObject kontenSkill;

  public GameObject footerEquip;
  public GameObject footerSkill;

  // Start is called before the first frame update
  void Start() {
    transformBtn(true);

    btnEquipment.onClick.AddListener(() => {
      transformBtn(true);
    });

    btnSkiil.onClick.AddListener(() => {
      transformBtn(false);
    });
  }

  public void transformBtn(bool isActive) {
    if (isActive == true) {
      btnEquipment.image.rectTransform.sizeDelta = new Vector2(320, 120);
      btnSkiil.image.rectTransform.sizeDelta = new Vector2(280, 80);
      kontenEquip.gameObject.SetActive(true);
      kontenSkill.gameObject.SetActive(false);
      footerEquip.gameObject.SetActive(true);
      footerSkill.gameObject.SetActive(false);
    } else {
      btnSkiil.image.rectTransform.sizeDelta = new Vector2(320, 120);
      btnEquipment.image.rectTransform.sizeDelta = new Vector2(280, 80);
      kontenEquip.gameObject.SetActive(false);
      kontenSkill.gameObject.SetActive(true);
      footerEquip.gameObject.SetActive(false);
      footerSkill.gameObject.SetActive(true);
    }
  }

}
