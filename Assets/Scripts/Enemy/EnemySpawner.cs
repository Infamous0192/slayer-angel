using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    [SerializeField] private GameObject enemy;

    public float enemyConcurency = 10f;
    private int enemyCount;
    private BoxCollider2D ground;

    private void Start() {
        ground = GameObject.Find("Ground").GetComponent<BoxCollider2D>();
        InvokeRepeating("Spawner", 0, enemyConcurency);
    }

    private void Update() {
        enemyCount = CountEnemies();
    }

    private int CountEnemies() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        return enemies.Length;
    }

    private void Spawner() {
        int count = (int)Random.Range(1, 4);
        StartCoroutine(SpawnEnemy(count));
    }

    private IEnumerator SpawnEnemy(int count) {
        for (int i = 0; i < count; i++) {
            yield return new WaitForSeconds(.75f);
            GameObject obj = Instantiate(enemy, transform);
            obj.transform.parent = gameObject.transform;
        }
    }
}
