using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraCharge : Skill {
    private Player player;
    private Animator animator;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        animator = player.GetComponent<Animator>();
        transform.position = new Vector2(player.transform.position.x - 0.1f, player.transform.position.y);
        StartCoroutine(Action());
    }

    private IEnumerator Action() {
        animator.SetTrigger(this.SkillName);
        /** only change code below **/
        player.HasAction = true;
        double baseRegen = player.HealthRegen;
        yield return new WaitForSeconds(1.95f);
        player.HealthRegen = baseRegen + 5f;
        player.HasAction = false;
        yield return new WaitForSeconds(5f);
        /** only change code above **/
        animator.ResetTrigger(this.SkillName);
        Destroy(gameObject);
    }
}
