using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraCharge : Skill {
    public float Duration;
    public float BaseRegen;

    private float regen;

    public override void OnStart() {
        transform.position = new Vector2(player.transform.position.x - 0.1f, player.transform.position.y);
        foreach (Skills skill in GameManager.Instance.Data.Skill) {
            if (skill.Name == this.Name) {
                regen = skill.Level * BaseRegen;
                StartCoroutine(Action());
                return;
            }
        }
    }

    private IEnumerator Action() {
        animator.SetTrigger(this.Name);
        /** only change code below **/
        player.HasAction = true;
        double baseRegen = player.HealthRegen;
        yield return new WaitForSeconds(1.95f);
        player.HealthRegen = regen;
        player.HasAction = false;
        yield return new WaitForSeconds(Duration);
        player.HealthRegen = baseRegen;
        /** only change code above **/
        Destroy(gameObject);
    }
}
