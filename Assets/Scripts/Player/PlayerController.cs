using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
  public Player player;
  public Animator animator;

  private void Start() {

  }

  private void Update() {
    animator.SetBool("IsAttacking", player.IsAttacking);

    // if (Input.GetKey(KeyCode.W) && !player.IsActioning) {
    //   animator.SetTrigger("AuraCharge");
    //   Instantiate(skill);
    //   player.IsActioning = true;
    // }
    // // jika tombol skill heal di tekan
    // else if (isSkill && !player.IsActioning) {
    //   animator.SetTrigger("AuraCharge");
    //   Instantiate(skill);
    //   player.IsActioning = true;
    // } else {
    //   isSkill = false;
    // }
  }
}
