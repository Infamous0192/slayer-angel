using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class SkillSlot {
    public bool IsUnlocked;
    public string SkillCode;

    public SkillSlot(bool isUnlocked) {
        SkillCode = "";
        IsUnlocked = isUnlocked;
    }

    public SkillSlot(string skillCode, bool isUnlocked) {
        SkillCode = skillCode;
        IsUnlocked = isUnlocked;
    }
}
