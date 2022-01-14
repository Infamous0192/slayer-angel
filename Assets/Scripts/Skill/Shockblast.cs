using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shockblast : Skill {
    [SerializeField] private GameObject effect;
    private bool isTriggered = false;

    public float BaseDamage;
    private float damage;

    public override void OnStart() {
        foreach (Skills skill in GameManager.Instance.Data.Skill) {
            if (skill.Name == this.Name) {
                damage = skill.Level * BaseDamage;
                StartCoroutine(Action());
                return;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collider) {
        if (isTriggered) {
            try {
                collider.GetComponent<Enemy>().TakeDamage(damage * Time.deltaTime);
            } catch (System.Exception) {
                collider.GetComponent<EnemyBoss>().TakeDamage(damage * Time.deltaTime);
            }
        }
    }

    private IEnumerator Action() {
        animator.Play("mc_shockblast");
        player.HasAction = true;
        yield return new WaitForSeconds(1f);
        isTriggered = true;
        GameObject effect = Instantiate(this.effect);
        yield return new WaitForSeconds(0.35f);
        Destroy(effect);
        Destroy(gameObject);
        player.HasAction = false;
    }
}
