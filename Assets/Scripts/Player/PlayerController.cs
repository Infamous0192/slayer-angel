using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public Player player;
    public Animator animator;
    public Skill skill;
    private bool isSkill = false;

    private void Start() {

    }

    private void Update() {
        animator.SetBool("IsAttacking", player.IsAttacking);

        if (Input.GetKey(KeyCode.W) && !player.IsActioning) {
            animator.SetTrigger("AuraCharge");
            Instantiate(skill);
            player.IsActioning = true;
        }
    }
}
