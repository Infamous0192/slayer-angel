using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    #region health
    public HealthBar healthBar;
    public float baseHealth = 100;
    private float _currentHealth;
    private float _maxHealth;
    public float CurrentHealth => _currentHealth;
    public float MaxHealth => _maxHealth;
    #endregion

    #region attack
    public int baseAttackSpeed = 100;
    public float baseAttackInterval = 1.7f;
    public int baseDamage = 25;
    public float AttackSpeed => baseAttackSpeed;
    public float AttackInterval => 1 / (AttackSpeed / (baseAttackSpeed * baseAttackInterval));
    public int AttackDamage => baseDamage;
    private float attackPeriod = 0;
    #endregion

    #region behaviour
    private bool isAttacking = false;
    #endregion

    #region movement
    public int baseMovementSpeed = 300;
    public float MovementSpeed => isAttacking ? 0 : baseMovementSpeed;
    #endregion

    public void TakeDamage(int damage) {
        _currentHealth -= damage;
        healthBar.SetHealth((int)_currentHealth);
    }

    private void Start() {
        _maxHealth = baseHealth;
        _currentHealth = _maxHealth;
        healthBar.SetMaxHealth((int)_currentHealth);
    }

    private void Update() {
        if (isAttacking) AttackEnemies();

        isAttacking = CheckEnemy();
    }

    private void AttackEnemies() {
        if (attackPeriod > AttackInterval) {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            for (int i = 0; i < enemies.Length; i++) {
                if (Vector2.Distance(transform.position, enemies[i].transform.position) < 2f) {
                    enemies[i].GetComponent<Enemy>().TakeDamage(AttackDamage);
                }
            }
            attackPeriod = 0;
        }
        attackPeriod += UnityEngine.Time.deltaTime;
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
