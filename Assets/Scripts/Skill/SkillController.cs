using UnityEngine;

public class SkillController : MonoBehaviour {
    private void Start() {
        Slot[] slot = GameManager.Instance.Data.Slot;
        for (int i = slot.Length - 1; i >= 0; i--) {
            if (slot[i].IsUnlocked) {
                if (slot[i].Skill != "") {
                    Instantiate(Resources.Load($"SkillButton/{slot[i].Skill}"), transform);
                } else {
                    Instantiate(Resources.Load("SkillButton/Empty"), transform);
                }
            } else {
                Instantiate(Resources.Load("SkillButton/Locked"), transform);
            }
        }
    }
}
