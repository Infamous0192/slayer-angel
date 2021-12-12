using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUpgradeChar : MonoBehaviour {


  public Button btnEquipment;

  public Button btnSkiil;


  public GameObject kontenEquip;
  public GameObject kontenSkill;
  public GameObject Menu;

  // public Sprite redSprite;
  // public Sprite greenSprite;


  // Start is called before the first frame update
  void Start() {
    transformBtn(true);

    btnEquipment.onClick.AddListener(() => {
      transformBtn(true);
    });

    btnSkiil.onClick.AddListener(() => {
      transformBtn(false);
    });

    // btnEquipment = this.gameObject.GetComponent<Button>();
    // btnSkiil = this.gameObject.GetComponent<Button>();

  }

  public void transformBtn(bool isActive) {
    if (isActive == true) {
      btnEquipment.image.rectTransform.sizeDelta = new Vector2(320, 80);
      btnSkiil.image.rectTransform.sizeDelta = new Vector2(253, 58);
      kontenEquip.gameObject.SetActive(true);
      kontenSkill.gameObject.SetActive(false);


      // SpriteState spriteState = new SpriteState();
      // SpriteState spriteState2 = new SpriteState();

      // spriteState2 = btnSkiil.spriteState;

      // if ((btnEquipment != null) && (redSprite != null) && (greenSprite != null)) {
      //   SpriteState spriteState = new SpriteState();
      //   spriteState = btnEquipment.spriteState;


      //   if (enabled) {
      //     spriteState.pressedSprite = redSprite;
      //   } else {
      //     spriteState.pressedSprite = greenSprite;
      //   }
      //   btnEquipment.spriteState = spriteState;

      // }

    } else {
      btnSkiil.image.rectTransform.sizeDelta = new Vector2(320, 80);
      btnEquipment.image.rectTransform.sizeDelta = new Vector2(253, 58);
      kontenEquip.gameObject.SetActive(false);
      kontenSkill.gameObject.SetActive(true);

    }
  }

}
