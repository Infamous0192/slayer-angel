using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSlotController : MonoBehaviour {
    public void RefreshSlot() {
        foreach (Transform child in transform) GameObject.Destroy(child.gameObject);

        Slot[] slots = GameManager.Instance.Data.Slot;
        foreach (Slot slot in slots) {
            if (slot.IsUnlocked) {
                if (slot.Skill != "") {
                    Instantiate(Resources.Load($"SlotButton/{slot.Skill}Slot"), transform);
                } else {
                    Instantiate(Resources.Load("SlotButton/EmptySlot"), transform);
                }
            } else {
                Instantiate(Resources.Load("SlotButton/LockedSlot"), transform);
            }
        }
    }

    private void Start() {
        RefreshSlot();
    }
}
