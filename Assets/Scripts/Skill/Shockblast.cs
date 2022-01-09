using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shockblast : Skill {
    [SerializeField] private GameObject effect;
    private bool isTriggered = false;

    public float Damage = 200;

    public override void OnStart() {
        StartCoroutine(Action());
    }

    private void OnTriggerStay2D(Collider2D collider) {
        if (isTriggered) {
            collider.GetComponent<Enemy>().TakeDamage(Damage * Time.deltaTime);
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
