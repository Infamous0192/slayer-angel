using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private int _maxHealth;
    private int _currentHealth;
    private float _movementSpeed = 3f;
    private int _baseAttackDamage = 50;
    private int _attackSpeed = 500;
    private float _attackPeriod = 0.0f;
    private bool _isAttacking = false;

    public float MovementSpeed => _isAttacking ? 0 : _movementSpeed;
    public float AttackInterval => _attackSpeed / 500;
    public int AttackDamage => _baseAttackDamage;

    // HealhBar
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    public void TakeDamage(int damage) {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    public void AttackEnemies() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (_attackPeriod > AttackInterval) {
            for (int i = 0; i < enemies.Length; i++) {
                if (Vector2.Distance(transform.position, enemies[i].transform.position) <= 1.5f) {
                    enemies[i].GetComponent<Enemy>().TakeDamage(AttackDamage);
                }
            }
        }

        _attackPeriod += UnityEngine.Time.deltaTime;
    }

    // Start is called before the first frame update
    void Start() {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update() {
        // if (Input.GetKey(KeyCode.RightArrow)) {
        //     MovementSpeed += 0.2f;
        // }

        // if (Input.GetKey(KeyCode.LeftArrow)) {
        //     MovementSpeed -= 0.2f;
        // }

        if (_isAttacking) AttackEnemies();

        if (Input.GetKeyDown(KeyCode.Space)) {
            TakeDamage(20);
        }

        _isAttacking = CheckEnemy();
    }

    private bool CheckEnemy() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        for (int i = 0; i < enemies.Length; i++) {
            if (Vector2.Distance(transform.position, enemies[i].transform.position) <= 1.5f) {
                return true;
            }
        }

        return false;
    }
}
