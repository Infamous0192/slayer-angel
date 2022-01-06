using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    #region attack

    public double AttackPower;
    public float AttackSpeed;
    [SerializeField] private float _attackInterval;
    public float AttackInterval => 1 / (AttackSpeed / (300 * _attackInterval));
    public float AttackRange;
    [Range(0, 1)] public float AttackStability;

    private float attackPeriod = 0;
    #endregion

    #region health
    [SerializeField] private HealthBar healthBar;
    public double MaxHealth;
    public double HealthRegen;
    public double CurrentHealth;
    #endregion

    #region mana
    public float BaseMana = 100;
    #endregion

    #region movement
    [SerializeField] private int _movementSpeed = 300;
    public float MovementSpeed => IsAttacking || HasAction ? 0 : _movementSpeed;
    #endregion

    #region behaviour
    private bool _isAttacking = false;
    public bool HasAction = false;
    public bool IsAttacking {
        get => _isAttacking;
        set {
            if (_isAttacking) Attack();
            if (value != _isAttacking) {
                _isAttacking = value;
                attackPeriod = 0;
                animator.SetBool("IsAttacking", value);
                animator.ResetTrigger("Attack");
            }
        }
    }
    #endregion

    private Animator animator;

    public void TakeDamage(int damage) {
        CurrentHealth -= damage;
        healthBar.SetHealth((int)CurrentHealth);
    }

    private void Start() {
        animator = GetComponent<Animator>();

        AttackPower += GameManager.Instance.Data.Stats.AttackPower;
        MaxHealth = GameManager.Instance.Data.Stats.MaxHealth;
        CurrentHealth = MaxHealth;

        healthBar.SetMaxHealth((int)MaxHealth);
        InvokeRepeating("Regenerate", 0, 1f);
    }

    private void FixedUpdate() {
        RaycastHit2D hitObstacle = Physics2D.Raycast(transform.position, Vector2.right, 1f);

        IsAttacking = hitObstacle.collider != null && hitObstacle.collider.tag == "Enemy";
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
        yield return new WaitForSeconds(0.2f);
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, AttackRange);
        foreach (Collider2D enemy in enemies) {
            double attackError = AttackPower - (100 * AttackStability / 100);
            enemy.GetComponent<Enemy>().TakeDamage(Random.Range((float)(AttackPower - attackError), (float)AttackPower));
        }
    }

    private void Regenerate() {
        CurrentHealth += HealthRegen;
    }
}
