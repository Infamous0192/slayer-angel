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

    private float heldTime = 0.0f;
    private Player player;

    [SerializeField]
    private Text DistanceText;

    private float distance = 0;

    public double StageDistance = 0;
    [Range(0f, 1f)]
    public float[] Checkpoint;

    public float EnemyMultiplier;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Update() {
        if (!player.IsAttacking) {
            Run();
        }
    }

    private void Run() {
        heldTime += Time.deltaTime;
        if (heldTime >= 0.2f) {
            distance += player.MovementSpeed / 300;
            DistanceText.text = $"{distance}m";
            heldTime = 0;
        }
    }
}


