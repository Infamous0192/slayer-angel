using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public double StageDistance = 1000;
    [Range(0f, 1f)]
    public float[] Checkpoint;

    public float EnemyMultiplier;

    private void Start() {

    }

    private void Update() {

    }
}


