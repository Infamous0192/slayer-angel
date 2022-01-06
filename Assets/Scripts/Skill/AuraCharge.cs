using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraCharge : Skill {
    private Player player;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        transform.position = new Vector2(player.transform.position.x - 0.1f, player.transform.position.y);
        StartCoroutine(Action());
    }

    private IEnumerator Action() {
        player.animator.SetTrigger(this.SkillName);
        /** only change code below **/
        player.HasAction = true;
        float baseRegen = player.HealthRegen;
        yield return new WaitForSeconds(1.95f);
        player.HealthRegen = baseRegen + 5f;
        player.HasAction = false;
        yield return new WaitForSeconds(5f);
        /** only change code above **/
        player.animator.ResetTrigger(this.SkillName);
        Destroy(gameObject);
    }
}
