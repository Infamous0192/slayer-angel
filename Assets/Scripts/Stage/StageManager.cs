using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private Player player;

    [SerializeField] private Text DistanceText;
    [SerializeField] private Text GoldText;

    private float distance = 0;

    public double StageDistance;
    [Range(0f, 1f)]
    public float[] Checkpoint;

    public float EnemyMultiplier;

    public void AddGold(double gold) {
        GameManager.Instance.Data.Stats.Gold += gold;
        GoldText.text = GameManager.Instance.Data.Stats.Gold.ToString("0,0");
    }

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        GoldText.text = GameManager.Instance.Data.Stats.Gold.ToString("0,0");
    }

    private void Update() {
        if (!player.IsAttacking) {
            Run();
        }
    }

    private void Run() {
        distance += player.MovementSpeed * Time.deltaTime / 300;
        DistanceText.text = $"{distance.ToString("0.0")}m";
    }
}


