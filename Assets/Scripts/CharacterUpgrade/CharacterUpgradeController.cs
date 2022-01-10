using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUpgradeController : MonoBehaviour {
    private void Start() {
        Equipment[] equipments = GameManager.Instance.Data.Equipment;
        foreach (Equipment equipment in equipments) {
            if (equipment.IsUnlocked) {
                Instantiate(Resources.Load($"CharacterUpgrade/{equipment.Name}Upgrade"), transform);
            } else {
                Instantiate(Resources.Load($"CharacterUpgrade/EquipmentLocked"), transform);
            }
        }
    }
}
