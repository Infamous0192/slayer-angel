using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    private Player player;

    #region health
    public EnemyHealthBar HealthBar;
    public float baseHealth = 50;
    private float _currentHealth;
    private float _maxHealth;
    public float CurrentHealth => _currentHealth;
    public float MaxHealth => _maxHealth;
    #endregion

    #region attack
    public int baseAttackSpeed = 100;
    public float baseAttackTime = 3f;
    public int baseDamage = 25;
    public float AttackRange = 1f;
    public float AttackSpeed => baseAttackSpeed;
    public float AttackInterval => 1 / (AttackSpeed / (100 * baseAttackTime));
    public int AttackDamage => baseDamage;
    private float attackPeriod = 0;
    #endregion

    #region behaviour
    private bool isAttacking = false;
    private bool isDead => _currentHealth <= 0;
    #endregion

    #region movement
    public float baseMovementSpeed = 300;
    public float MovementSpeed => isAttacking ? 0 : baseMovementSpeed;
    #endregion

    #region reward
    public double GoldYield = 300;
    #endregion

    private Rigidbody2D rb2d;

    public void TakeDamage(int damage) {
        _currentHealth -= damage;
        HealthBar.SetHealth((int)CurrentHealth, (int)MaxHealth);
        if (CurrentHealth <= 0) Dead();
    }

    private void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _maxHealth = baseHealth;
        _currentHealth = _maxHealth;

        HealthBar.SetHealth((int)CurrentHealth, (int)MaxHealth);
    }

    private void FixedUpdate() {
        if (isAttacking) AttackPlayer();
        else Move();

        if (isDead) Destroy(gameObject);

        isAttacking = IsPlayerAhead();
    }

    private void Dead() {
        GameManager.Instance.AddGold(GoldYield);
        Destroy(gameObject);
    }

    private bool IsPlayerAhead() {
        return Vector2.Distance(transform.position, player.transform.position) <= AttackRange;
    }

    private void AttackPlayer() {
        rb2d.velocity = new Vector2(0, 0);
        attackPeriod += Time.deltaTime;
        if (attackPeriod > AttackInterval) {
            player.TakeDamage(AttackDamage);
            attackPeriod = 0;
        }
    }

    private void Move() {
        rb2d.velocity = new Vector2((MovementSpeed + player.MovementSpeed) / -120, 0);
    }
}
