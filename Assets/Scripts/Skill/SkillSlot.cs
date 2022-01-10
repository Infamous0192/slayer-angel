using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSlot : MonoBehaviour {
    public string Name;

    [SerializeField] private Button UnequipButton;

    void Start() {
        UnequipButton.onClick.AddListener(() => {
            foreach (Slot slot in GameManager.Instance.Data.Slot) {
                if (slot.Skill == Name) {
                    slot.Skill = "";
                    GameObject.Find("Skill Slot").GetComponent<SkillSlotController>().RefreshSlot();
                }
            }
        });
    }
}
