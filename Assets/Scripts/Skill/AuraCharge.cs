using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraCharge : Skill {
    public float Duration;

    public override void OnStart() {
        transform.position = new Vector2(player.transform.position.x - 0.1f, player.transform.position.y);
        StartCoroutine(Action());
    }

    private IEnumerator Action() {
        animator.SetTrigger(this.Name);
        /** only change code below **/
        player.HasAction = true;
        double baseRegen = player.HealthRegen;
        yield return new WaitForSeconds(1.95f);
        player.HealthRegen = baseRegen + 20f;
        player.HasAction = false;
        yield return new WaitForSeconds(Duration);
        player.HealthRegen = baseRegen;
        /** only change code above **/
        Destroy(gameObject);
    }
}
