using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public static GameManager Instance;

    private const string PROGRESS_KEY = "Progress";

    public UserProgressData Progress;
    public SaveData Data;

    public void AddGold(double value) {
        Data.Stats.Gold += value;
    }

    void Awake() {
        if (Instance == null) {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        } else if (Instance != this) {
            Destroy(gameObject);
        }
    }

    private void Start() {
        // Load();
        // InvokeRepeating("Save", 0, 5f);
        Data = new SaveData();
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
