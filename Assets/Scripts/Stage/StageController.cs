using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageController : MonoBehaviour {
    public Slider ProgressBar;
    public Sprite Flag;

    private void Start() {
        ProgressBar.maxValue = (float) StageManager.Instance.StageDistance;
        ProgressBar.value = (float) GameManager.Instance.Progress.RunDistance;
        Vector2 pos = ProgressBar.transform.position;

        Instantiate(Flag, pos, Quaternion.identity);
    }

    private void Update() {
        ProgressBar.value = (float) GameManager.Instance.Progress.RunDistance;
    }
}
