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

    public UserProgressData Progress = new UserProgressData();
    public Text GoldInfo;

    private Player _player;

    public void AddGold(double value) {
        Progress.Gold += value;
        GoldInfo.text = Progress.Gold.ToString("0");
    }

    private void Start() {
        Load();
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        InvokeRepeating("Run", 0, 1f);
        InvokeRepeating("Save", 0, 5f);
    }

    private void Load() {
        if (PlayerPrefs.HasKey(PROGRESS_KEY)) {
            string json = PlayerPrefs.GetString(PROGRESS_KEY);
            Progress = JsonUtility.FromJson<UserProgressData>(json);
        }
        GoldInfo.text = Progress.Gold.ToString("0");
    }

    private void Save() {
        string json = JsonUtility.ToJson(Progress);
        PlayerPrefs.SetString(PROGRESS_KEY, json);
    }

    private void Run() {
        Progress.RunDistance += _player.MovementSpeed / 100;
    }
}
