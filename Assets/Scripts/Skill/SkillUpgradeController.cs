using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillUpgradeController : MonoBehaviour {
    public void RefreshSlot() {
        foreach (Transform child in transform) GameObject.Destroy(child.gameObject);

        Skills[] skills = GameManager.Instance.Data.Skill;
        foreach (Skills skill in skills) {
            if (skill.IsUnlocked) {
                Instantiate(Resources.Load($"SkillUpgrade/{skill.Name}"), transform);
            } else {
                Instantiate(Resources.Load("SkillUpgrade/SkillLocked"), transform);
            }
        }
    }

    private void Start() {
        RefreshSlot();
    }
}
