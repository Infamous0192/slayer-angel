using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    private Animator animator;
    public bool IsDead = false;

    void Start() {
        animator = GetComponent<Animator>();
    }

    void Update() {
        if (IsDead) Destroy(gameObject);
        if (Input.GetKeyDown(KeyCode.D)) {
            animator.SetBool("IsAttacking", !animator.GetBool("IsAttacking"));
        }
        if (Input.GetKeyDown(KeyCode.R)) {
            animator.SetTrigger("Dead");
            // Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length / 1.5f);
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            animator.SetTrigger("Attack");
        }
    }
}
