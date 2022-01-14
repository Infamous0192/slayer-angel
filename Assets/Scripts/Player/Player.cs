using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
  //SoundFX
  [SerializeField]
  private AudioSource soundDead;
  [SerializeField]
  private AudioSource soundAttack;


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
  private double _currentHealth;
  public double MaxHealth;
  public double HealthRegen;
  public double CurrentHealth {
    get => _currentHealth;
    set {
      _currentHealth = value >= MaxHealth ? MaxHealth : value;
      healthBar.SetHealth((int)_currentHealth);

      if (_currentHealth <= 0) IsDead = true;
    }
  }
  #endregion

  #region mana
  [SerializeField] private PlayerManaBar manaBar;
  private double _currentMana = 100;
  public double MaxMana;
  public double ManaRegen;
  public double CurrentMana {
    get => _currentMana;
    set {
      _currentMana = value >= MaxMana ? MaxMana : value;
      manaBar.SetMana((float)_currentMana);
    }
  }
  #endregion

  #region movement
  [SerializeField] private int _movementSpeed = 300;
  public float MovementSpeed => IsAttacking || HasAction || IsDead ? 0 : _movementSpeed;
  #endregion

  #region behaviour
  private bool _isDead = false;
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
  public bool IsDead {
    get => _isDead;
    set {
      if (_isDead == value) return;
      _isDead = value;
      if (_isDead == true) {
        StartCoroutine(Dead());
      }
    }
  }
  #endregion

  private Animator animator;

  private void Start() {
    animator = GetComponent<Animator>();

    AttackPower = GameManager.Instance.Data.Stats.AttackPower;
    MaxHealth = GameManager.Instance.Data.Stats.MaxHealth;
    MaxMana = GameManager.Instance.Data.Stats.MaxMana;
    CurrentMana = MaxMana;
    CurrentHealth = MaxHealth;

    manaBar.SetMaxMana((int)MaxMana);
    healthBar.SetMaxHealth((int)MaxHealth);
  }

  private void FixedUpdate() {
    if (IsDead) return;
    RaycastHit2D hitObstacle = Physics2D.Raycast(transform.position, Vector2.right, 1f);

    CurrentHealth += HealthRegen * Time.fixedDeltaTime;
    CurrentMana += ManaRegen * Time.fixedDeltaTime;

    IsAttacking = hitObstacle.collider != null && hitObstacle.collider.tag == "Enemy";
  }

  private IEnumerator Dead() {
    animator.Play("mc_death");
    soundDead.Play();
    yield return new WaitForSeconds(1f);
    StageManager.Instance.LoadLoseScreen();
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
    soundAttack.Play();
    yield return new WaitForSeconds(0.2f);
    Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, AttackRange);
    double damage = Random.Range((float)(AttackPower * AttackStability), (float)AttackPower);

    foreach (Collider2D enemy in enemies) {
      enemy.GetComponent<Enemy>().TakeDamage(damage);
    }
    yield return new WaitForSeconds(0.1f);
  }
}
