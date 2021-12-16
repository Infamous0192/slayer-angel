using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraCharge : Skill {
    private Player player;
    public Animator animator;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        transform.position = new Vector2(player.transform.position.x - 0.2f, player.transform.position.y);
        StartCoroutine(Action());
    }

    private IEnumerator Action() {
        float baseRegen = player.HealthRegen;
        yield return new WaitForSeconds(1.95f);
        player.HealthRegen = baseRegen + 5f;
        player.IsActioning = false;
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
