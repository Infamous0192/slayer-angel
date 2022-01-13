using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageController : MonoBehaviour {
    [SerializeField] private Text NameText;
    [SerializeField] private Text TitleText;
    [SerializeField] private Text DescriptionText;

    [SerializeField] private Button PreviousButton;
    [SerializeField] private Button NextButton;
    [SerializeField] private Button PlayButton;

    [SerializeField] private GameObject RewardContainer;

    private Stage[] stage;
    private int index = 0;

    private void Start() {
        stage = GameManager.Instance.Data.Stage;
        LoadStage(index);

        PreviousButton.onClick.AddListener(() => {
            if (index > 0) LoadStage(--index);
        });
        NextButton.onClick.AddListener(() => {
            if (index < stage.Length - 1) {
                LoadStage(++index);
            }
        });
    }

    private void LoadStage(int index) {
        NameText.text = stage[index].Name;
        TitleText.text = stage[index].Title;
        DescriptionText.text = stage[index].Description;
        PlayButton.onClick.RemoveAllListeners();

        PlayButton.onClick.AddListener(() => {
            SceneManager.LoadScene(stage[index].SceneName);
        });

        foreach (Transform child in RewardContainer.transform) {
            Destroy(child.gameObject);
        }

        Instantiate(stage[index].Reward[0], RewardContainer.transform.position, Quaternion.identity, RewardContainer.transform);
    }
}
