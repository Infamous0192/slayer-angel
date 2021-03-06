using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUpgrade : MonoBehaviour {
    public string Name;
    public float CostMultiplier;
    private int _level = 1;
    public int Level {
        get => _level;
        set {
            if (_level == value) return;
            _level = value;
            OnLevelUp();
        }
    }

    public double BaseCost;

    // use Geometrical Progression to calculate the next cost
    public double Cost => BaseCost * Mathf.Pow(CostMultiplier, Level - 1);

    public double UpgradeAddition;

    public Text LevelText;
    public Text CostText;
    public Button UpgradeButton;

    private Equipment[] equipments;

    public virtual void OnUpgrade() { }

    private void Start() {
        LoadSaveData();
        LevelText.text = $"Lv. {Level}";
        CostText.text = $"{(int)Cost}";
        UpgradeButton.onClick.AddListener(() => {
            if (GameManager.Instance.Data.Stats.Gold > Cost) {
                GameManager.Instance.Data.Stats.Gold -= Cost;
                Level++;
                OnUpgrade();
            }
        });
    }

    public void LoadSaveData() {
        equipments = GameManager.Instance.Data.Equipment;
        foreach (Equipment equipment in equipments) {
            if (equipment.Name == this.Name) {
                this.Level = equipment.Level;
                return;
            }
        }
    }

    private void OnLevelUp() {
        LevelText.text = $"Lv. {Level}";
        CostText.text = $"{(int)Cost}";
        foreach (Equipment equipment in equipments) {
            if (equipment.Name == this.Name) {
                equipment.Level++;
                return;
            }
        }
    }
}
