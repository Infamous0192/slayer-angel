using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour {
    private static StageManager _instance = null;
    public static StageManager Instance {
        get {
            if (_instance == null) {
                _instance = FindObjectOfType<StageManager>();
            }

            return _instance;
        }
    }

    public string StageName;
    public double StageDistance;
    public int EnemyLevel;
    public float[] Checkpoint;

    private double _playerDistance;
    public double PlayerDistance {
        get => _playerDistance;
        set {
            _playerDistance = value;
            DistanceText.text = $"{PlayerDistance.ToString("0.0")}m";
        }
    }

    [SerializeField] private Text DistanceText;
    [SerializeField] private Text GoldText;

    private Player player;

    public Stage stage;
    private int checkpointIndex = 0;
    private double nextCheckpoint;

    private bool _isCompleted = false;
    public bool IsCompleted {
        get => _isCompleted;
        set {
            if (_isCompleted == value) return;
            _isCompleted = value;
            if (value == true) {
                LoadWinScreen();
            }
        }
    }

    public void AddGold(double gold) {
        GameManager.Instance.Data.Stats.Gold += gold;
        GoldText.text = GameManager.Instance.Data.Stats.Gold.ToString("0,0");
    }

    public void LoadWinScreen() {
        Time.timeScale = 0;
        SceneManager.LoadScene("WinScreen", LoadSceneMode.Additive);
    }

    public void LoadLoseScreen() {
        Time.timeScale = 0;
        SceneManager.LoadScene("LoseScreen", LoadSceneMode.Additive);
    }

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        LoadStage();
    }

    private void FixedUpdate() {
        if (!player.IsAttacking) {
            Run();
        }
    }

    private void LoadStage() {
        foreach (Stage stage in GameManager.Instance.Data.Stage) {
            if (stage.Name == StageName) {
                this.stage = stage;
                PlayerDistance = StageDistance * stage.Checkpoint;

                if (stage.Checkpoint == 1) {
                    _isCompleted = true;
                    nextCheckpoint = -1;
                    return;
                }

                if (stage.Checkpoint > 0) {
                    checkpointIndex = Array.IndexOf(Checkpoint, stage.Checkpoint);
                }
                if (Checkpoint.Length == checkpointIndex + 1) {
                    nextCheckpoint = StageDistance;
                } else {
                    nextCheckpoint = StageDistance * Checkpoint[checkpointIndex];
                }
                return;
            }
        }
    }

    private void Run() {
        if (stage.Checkpoint != 1) {
            PlayerDistance += player.MovementSpeed * Time.deltaTime / 300;
        }

        if (PlayerDistance >= nextCheckpoint) {
            if (StageDistance == nextCheckpoint) {
                stage.Checkpoint = 1;
                nextCheckpoint = -1;
                IsCompleted = true;
            } else {
                stage.Checkpoint = Checkpoint[checkpointIndex];
                if (checkpointIndex == Checkpoint.Length - 1) {
                    nextCheckpoint = StageDistance;
                } else {
                    nextCheckpoint = StageDistance * Checkpoint[++checkpointIndex];
                }
            }
        }
    }
}
