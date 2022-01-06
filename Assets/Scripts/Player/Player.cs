using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    #region attack
    public int baseAttackSpeed = 100;
    public float baseAttackInterval = 1.7f;
    public int baseDamage = 25;
    public float AttackRange = 1f;
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

    #region movement
    public int baseMovementSpeed = 300;
    public float MovementSpeed => IsAttacking || HasAction ? 0 : baseMovementSpeed;
    #endregion

    #region behaviour
    private bool _isAttacking = false;
    public bool HasAction = false;
    public bool IsAttacking {
        get => _isAttacking;
        set {
            if (value != _isAttacking) {
                _isAttacking = value;
                attackPeriod = 0;
                animator.SetBool("IsAttacking", value);
                animator.ResetTrigger("Attack");
            }
        }
    }
    #endregion

    public Animator animator;

    public void TakeDamage(int damage) {
        _currentHealth -= damage;
        healthBar.SetHealth((int)_currentHealth);
    }

    private void Start() {
        _maxHealth = baseHealth;
        _currentHealth = _maxHealth;
        healthBar.SetMaxHealth((int)_currentHealth);
        InvokeRepeating("Regenerate", 0, 1f);
    }

    private void FixedUpdate() {
        RaycastHit2D hitObstacle = Physics2D.Raycast(transform.position, Vector2.right, 1f);

        if (hitObstacle.collider != null && hitObstacle.collider.tag == "Enemy") {
            Attack();
            IsAttacking = true;
        } else {
            IsAttacking = false;
        }
    }

    private void Attack() {
        attackPeriod += Time.deltaTime;
        if (attackPeriod >= AttackInterval) {
            // create delay between animation and attack enemies
            StartCoroutine(AttackEnemies());
            attackPeriod = 0;
        }
    }

    private IEnumerator AttackEnemies() {
        animator.SetTrigger("Attack");
        yield return new WaitForSeconds(0.1f);
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, AttackRange);
        foreach (Collider2D enemy in enemies) {
            enemy.GetComponent<Enemy>().TakeDamage(AttackDamage);
        }
    }

    private void Regenerate() {
        _currentHealth += HealthRegen;
    }
}
