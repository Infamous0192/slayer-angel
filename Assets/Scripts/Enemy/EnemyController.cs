using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public Enemy enemy;

    // Start is called before the first frame update
    void Start() {
        enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update() {
        if (enemy.IsAttacking) enemy.AttackPlayer();
        else Move();
    }

    private void Move() {
        Vector2 pos = transform.position;
        pos.x -= enemy.MovementSpeed;

        transform.position = pos;
    }
}
