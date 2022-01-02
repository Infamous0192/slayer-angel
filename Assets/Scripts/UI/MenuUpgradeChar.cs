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

    public Text GoldText;
    public Text APText;
    public Text HPText;
    public Text MPText;

    // Temporary variable to check changes on the manager
    private double gold;
    private double ap;
    private double hp;
    private double mp;

    private void Start() {
        transformBtn(true);

        btnEquipment.onClick.AddListener(() => {
            transformBtn(true);
        });

        btnSkiil.onClick.AddListener(() => {
            transformBtn(false);
        });

        RefreshStats();
    }

    private void Update() {
        // Check stats on changes
        if (GameManager.Instance.Data.Stats.Gold != gold) RefreshStats();
        if (GameManager.Instance.Data.Stats.AttackPower != ap) RefreshStats();
        if (GameManager.Instance.Data.Stats.MaxHealth != hp) RefreshStats();
        if (GameManager.Instance.Data.Stats.MaxMana != mp) RefreshStats();
    }

    /**
    * Used to refresh stats in the UI and reassign temp variable
    */
    private void RefreshStats() {
        gold = GameManager.Instance.Data.Stats.Gold;
        ap = GameManager.Instance.Data.Stats.AttackPower;
        hp = GameManager.Instance.Data.Stats.MaxHealth;
        mp = GameManager.Instance.Data.Stats.MaxMana;

        GoldText.text = $"{gold.ToString("C0")}".Substring(1);
        APText.text = $": {(int)ap}";
        HPText.text = $": {(int)hp}";
        MPText.text = $": {(int)mp}";
    }

    private void transformBtn(bool isActive) {
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
