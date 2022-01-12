using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    #region attack
    public int BaseAttackPower;
    public float AttackMultipier;
    public float AttackRange;
    public float AttackSpeed;
    public float AttackInterval => 1 / (AttackSpeed / (300 * 2));
    public float AttackPower => BaseAttackPower * damageMultiplier;
    private float damageMultiplier;
    private float attackPeriod = 0;
    #endregion

    #region health
    private EnemyHealthBar healthBar;
    public double BaseHealth;
    public float HealthMultiplier;
    private double _currentHealth;
    public double CurrentHealth {
        get => _currentHealth;
        set {
            _currentHealth = value;
            healthBar.SetHealth((int)_currentHealth, (int)MaxHealth);
        }
    }
    private double _maxHealth;
    public double MaxHealth => _maxHealth;
    #endregion

    #region behaviour
    private bool _isAttacking = false;
    public bool IsAttacking {
        get => _isAttacking;
        set {
            if (_isAttacking) {
                rb2d.velocity = Vector2.zero;
                AttackPlayer();
            } else {
                rb2d.velocity = (Vector2.left * (MovementSpeed + player.MovementSpeed)) / 120;
            }
            if (value != _isAttacking) {
                _isAttacking = value;
                attackPeriod = 0;
                animator.SetBool("IsAttacking", value);
                animator.ResetTrigger("Attack");
            }
        }
    }
    private bool isDead => _currentHealth <= 0;
    #endregion

    #region movement
    [SerializeField] private float _movementSpeed;
    public float MovementSpeed => IsAttacking ? 0 : _movementSpeed;
    #endregion

    #region reward
    public double BaseGoldYield;
    private double goldYield;
    #endregion

    private Player player;
    private BoxCollider2D box;
    private Rigidbody2D rb2d;
    private Animator animator;

    public void TakeDamage(double damage) {
        CurrentHealth -= damage;
        if (CurrentHealth <= 0) Dead();
    }

    private void Start() {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
        healthBar = GetComponentInChildren<EnemyHealthBar>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        BoxCollider2D ground = GameObject.Find("Ground").GetComponent<BoxCollider2D>();
        float groundTop = ground.transform.position.y + (ground.size.y / 2);

        transform.position = new Vector2(transform.position.x, groundTop + (box.size.y / 2));

        int enemyLevel = StageManager.Instance.EnemyLevel;

        damageMultiplier = Mathf.Pow(AttackMultipier, enemyLevel);

        _maxHealth = BaseHealth * Mathf.Pow(HealthMultiplier, enemyLevel);
        _currentHealth = _maxHealth;

        healthBar.SetHealth((int)CurrentHealth, (int)MaxHealth);
    }

    private void FixedUpdate() {
        if (isDead) Destroy(gameObject);

        IsAttacking = IsPlayerAhead();
    }

    private void Dead() {
        StageManager.Instance.AddGold(BaseGoldYield);
        Destroy(gameObject);
    }

    private bool IsPlayerAhead() {
        return Vector2.Distance(transform.position, player.transform.position) <= AttackRange + 0.5f;
    }

    private void AttackPlayer() {
        attackPeriod += Time.deltaTime;
        if (attackPeriod > AttackInterval) {
            player.TakeDamage((int)AttackPower);
            animator.SetTrigger("Attack");
            attackPeriod = 0;
        }
    }
}
