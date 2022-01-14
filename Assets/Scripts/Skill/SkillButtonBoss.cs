using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButtonBoss : MonoBehaviour {
    [SerializeField] private Skill skill;
    [SerializeField] private Button button;
    [SerializeField] private Image icon;
    [SerializeField] private Text cooldownText;
    private float cooldown = 0;
    private bool _isCooldown = false;
    private bool IsCooldown {
        get => _isCooldown;
        set {
            if (value != _isCooldown) {
                _isCooldown = value;
                if (value) {
                    icon.color = new Color32(150, 150, 150, 255);
                    cooldownText.gameObject.SetActive(true);
                } else {
                    icon.color = new Color32(255, 255, 255, 255);
                    cooldownText.gameObject.SetActive(false);
                }
            }
        }
    }

    private PlayerBoss player;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBoss>();

        button.onClick.AddListener(() => {
            if (cooldown <= 0 && player.CurrentMana >= skill.ManaCost && !player.HasAction) {
                IsCooldown = true;
                cooldown = skill.Cooldown;
                player.CurrentMana -= skill.ManaCost;
                Instantiate(skill);
            }
        });
    }

    private void Update() {
        if (cooldown > 0) {
            cooldown -= 1 * Time.deltaTime;
            cooldownText.text = $"{cooldown.ToString("0.0")}s";
        }
        IsCooldown = cooldown > 0;
    }
}
