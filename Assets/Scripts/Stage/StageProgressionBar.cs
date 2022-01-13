using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageProgressionBar : MonoBehaviour {
    [SerializeField] private GameObject border;
    [SerializeField] private GameObject flagPrefabs;

    private Slider progressBar;
    private RectTransform container;


    public void SetValue(float value) {
        if (progressBar.value != value)
            progressBar.value = value;
    }

    private void Start() {
        progressBar = GetComponent<Slider>();
        container = border.GetComponent<RectTransform>();
        progressBar.maxValue = (float)StageManager.Instance.StageDistance;
        progressBar.value = (float)GameManager.Instance.Progress.RunDistance;

        float[] checkpoint = StageManager.Instance.Checkpoint;

        float width = container.rect.width;

        foreach (float item in checkpoint) {
            GameObject flag = Instantiate(flagPrefabs, container);
            RectTransform rect = flag.GetComponent<RectTransform>();

            rect.anchoredPosition = new Vector2((container.rect.width * item) + (rect.rect.width / 2), rect.anchoredPosition.y);
        }
    }

    private void Update() {
        SetValue((float)StageManager.Instance.PlayerDistance);
    }
}
