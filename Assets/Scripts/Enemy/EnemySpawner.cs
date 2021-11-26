using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public Enemy enemy;
    private int _enemyCount = 0;

    // Start is called before the first frame update
    void Start() {
        enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update() {
        _enemyCount = CountEnemies();
    }

    private int CountEnemies() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        return enemies.Length;
    }

    private void SpawnEnemy() {
        Instantiate(enemy.gameObject, new Vector2(2, 2), transform.rotation);
    }
}
