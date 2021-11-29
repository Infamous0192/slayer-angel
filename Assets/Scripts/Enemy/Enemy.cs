using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
  private Player player;
  private int _currentHealth;
  private int _maxHealth;
  private int _movementSpeed = 750;
  private int _baseAttackDamage = 5;
  private int _attackSpeed = 500;
  private float _attackPeriod = 0.0f;
  private bool _isAttacking = false;

  public bool IsDead => _currentHealth <= 0;
  public double CurrentHealth => _currentHealth;
  public double MaxHealth => _maxHealth;

  public EnemyHealthBar HealthBar;
  public float MovementSpeed => (float)_movementSpeed / 25000;
  public float AttackInterval => _attackSpeed / 500;
  public float AttackDamage => _baseAttackDamage;
  public bool IsAttacking => _isAttacking;

  public void AttackPlayer() {
    if (_attackPeriod > AttackInterval) {
      player.TakeDamage(5);
      _attackPeriod = 0;
    }
    _attackPeriod += UnityEngine.Time.deltaTime;
  }

  public void TakeDamage(int damage) {
    _currentHealth -= damage;
    HealthBar.SetHealth(_currentHealth, _maxHealth);
    if (CurrentHealth <= 0) {
      Destroy(gameObject);
    }
  }

  private void Start() {
    _maxHealth = 100 * 100;
    _currentHealth = _maxHealth;

    HealthBar.SetHealth(_currentHealth, _maxHealth);

    player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
  }

  private void Update() {
    Debug.Log(_currentHealth);
    if (IsAttacking) AttackPlayer();
    else Move();

    if (IsDead) Destroy(gameObject);

    _isAttacking = IsPlayerAhead();
  }

  private bool IsPlayerAhead() {
    float distance = Vector2.Distance(transform.position, player.transform.position);

    if (distance <= 1.5f) return true;

    return false;
  }

  private void Move() {
    Vector2 pos = transform.position;
    pos.x -= MovementSpeed;

    transform.position = pos;
  }
}
