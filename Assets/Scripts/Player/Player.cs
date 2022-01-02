using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    #region attack
    public int baseAttackSpeed = 100;
    public float baseAttackInterval = 1.7f;
    public int baseDamage = 25;
    public float AttackSpeed => baseAttackSpeed;
    public float AttackInterval => 1 / (AttackSpeed / (baseAttackSpeed * baseAttackInterval));
    public int AttackDamage => baseDamage;
    private float attackPeriod = 0;
    #endregion

    #region health
    public HealthBar healthBar;
    public float baseHealth = 100;
    private float _currentHealth;
    private float _maxHealth;
    public float HealthRegen = 0.1f;
    public float CurrentHealth => _currentHealth;
    public float MaxHealth => _maxHealth;
    #endregion

    #region mana
    public float BaseMana = 100;
    #endregion

    #region behaviour
    private bool _isEnemyAhead = false;
    public bool HasAction = false;
    public bool IsEnemyAhead => _isEnemyAhead;
    public bool IsAttacking => IsEnemyAhead;
    #endregion

    #region movement
    public int baseMovementSpeed = 300;
    public float MovementSpeed => IsEnemyAhead || HasAction ? 0 : baseMovementSpeed;
    #endregion

    public void TakeDamage(int damage) {
        _currentHealth -= damage;
        healthBar.SetHealth((int)_currentHealth);
    }

    private void Start() {
        _maxHealth = baseHealth;
        _currentHealth = _maxHealth;
        healthBar.SetMaxHealth((int)_currentHealth);
        InvokeRepeating("RegenHealth", 0, 1f);
    }

    private void Update() {
        if (IsEnemyAhead) AttackEnemies();

        _isEnemyAhead = CheckEnemy();
    }

    private void RegenHealth() {
        _currentHealth += HealthRegen;
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
            if (Vector2.Distance(transform.position, enemies[i].transform.position) <= 1f) {
                return true;
            }
        }

        return false;
    }
}
