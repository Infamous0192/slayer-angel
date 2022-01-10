using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUpgrade : MonoBehaviour {
    public Text LevelText;
    public Text CostText;
    public Button UpgradeButton;
    public Button EquipButton;

    public string Name;
    public float CostMultiplier;
    private int _level = 1;
    public int Level {
        get => _level;
        set {
            if (_level == value) return;
            _level = value;
            LevelText.text = $"Lv. {Level}";
            CostText.text = $"{(int)Cost}";
        }
    }

    public double BaseCost;

    // use Geometrical Progression to calculate the next cost
    public double Cost => BaseCost * Mathf.Pow(CostMultiplier, Level - 1);

    private bool _isEquiped = false;
    public bool IsEquiped {
        get => _isEquiped;
        set {
            if (value != _isEquiped) {
                _isEquiped = value;
                EquipButton.GetComponentInChildren<Text>().text = value ? "Unequip" : "Equip";
            }
        }
    }

    private Skills[] skill;
    private Slot[] slot;
    private int skillIndex;
    private int slotIndex;

    private void Start() {
        LoadSaveData();
        LevelText.text = $"Lv. {Level}";
        CostText.text = $"{(int)Cost}";
        UpgradeButton.onClick.AddListener(OnUpgrade);
        EquipButton.onClick.AddListener(OnEquip);
    }

    private void Update() {
        // IsEquiped = GameManager.Instance.Data.Slot[slotIndex].Skill != "";
    }

    private void OnUpgrade() {
        if (GameManager.Instance.Data.Stats.Gold > Cost) {
            GameManager.Instance.Data.Stats.Gold -= Cost;
            GameManager.Instance.Data.Skill[skillIndex].Level++;
            Level++;
        }
    }

    private void OnEquip() {
        if (IsEquiped) {
            foreach (Slot slot in GameManager.Instance.Data.Slot) {
                if (slot.Skill == Name) {
                    slot.Skill = "";
                    GameObject.Find("Skill Slot").GetComponent<SkillSlotController>().RefreshSlot();
                }
            }
        } else {
            foreach (Slot slot in GameManager.Instance.Data.Slot) {
                if (slot.IsUnlocked && slot.Skill == "") {
                    slot.Skill = Name;
                    GameObject.Find("Skill Slot").GetComponent<SkillSlotController>().RefreshSlot();
                    break;
                }
            }
        }

        IsEquiped = !IsEquiped;
    }

    private void LoadSaveData() {
        skill = GameManager.Instance.Data.Skill;
        slot = GameManager.Instance.Data.Slot;
        for (int i = 0; i < skill.Length; i++) {
            if (skill[i].Name == this.Name) {
                this.Level = skill[i].Level;
                skillIndex = i;
                break;
            }
        }
        for (int i = 0; i < slot.Length; i++) {
            if (slot[i].Skill == this.Name) {
                IsEquiped = true;
                slotIndex = i;
                return;
            }
        }
    }
}
