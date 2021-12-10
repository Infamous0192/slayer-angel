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

    public UserProgressData Progress = new UserProgressData();

    public Text GoldInfo;

    public void AddGold(double value) {
        Progress.Gold += value;
        GoldInfo.text = Progress.Gold.ToString("0");
    }

    private void Start() {
        GoldInfo.text = Progress.Gold.ToString("0");
    }

    private void Update() {

    }
}
