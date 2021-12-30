using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour {
  // Default Skill Slot
  private SkillSlot[] slot = {
    new SkillSlot("Shockblast", true),
    new SkillSlot("AuraCharge", true),
    new SkillSlot(false),
    new SkillSlot(false)
  };

  private void Start() {
    // load skill slot by loop slot backward
    for (int i = slot.Length - 1; i >= 0; i--) {
      if (slot[i].IsUnlocked) {
        Instantiate(Resources.Load($"SkillButton/{slot[i].SkillCode}"), transform);
      } else {
        Instantiate(Resources.Load("SkillButton/Locked"), transform);
      }
    }
  }

  private void Update() {

  }
}
