using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    private static GameManager _instance = null;
    public static GameManager Instance {
        get {
            if (_instance == null) {
                _instance = FindObjectOfType<GameManager>();
            }

            return _instance;
        }
    }

    private const string PROGRESS_KEY = "Progress";

    public UserProgressData Progress;
    public SaveData Data;

    public void AddGold(double value) {
        Data.Stats.Gold += value;
    }

    private void Start() {
        // Load();
        // InvokeRepeating("Save", 0, 5f);
        Data = new SaveData();
        Data.Stats.Gold = 1000;
    }

    private void Load() {
        if (PlayerPrefs.HasKey(PROGRESS_KEY)) {
            string json = PlayerPrefs.GetString(PROGRESS_KEY);
            Progress = JsonUtility.FromJson<UserProgressData>(json);
        }
    }

    private void Save() {
        string json = JsonUtility.ToJson(Progress);
        PlayerPrefs.SetString(PROGRESS_KEY, json);
    }
}
