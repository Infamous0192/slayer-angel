using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageController : MonoBehaviour {
    public Stage[] Stage;

    [SerializeField] private Text NameText;
    [SerializeField] private Text TitleText;
    [SerializeField] private Text DescriptionText;

    [SerializeField] private Button PreviousButton;
    [SerializeField] private Button NextButton;
    [SerializeField] private Button PlayButton;

    [SerializeField] private GameObject RewardContainer;

    private int index = 0;

    private void Start() {
        LoadStage(index);

        PreviousButton.onClick.AddListener(() => {
            if (index > 0) LoadStage(--index);
        });
        NextButton.onClick.AddListener(() => {
            if (index < Stage.Length - 1) {
                LoadStage(++index);
            }
        });
    }

    private void LoadStage(int index) {
        NameText.text = Stage[index].Name;
        TitleText.text = Stage[index].Title;
        DescriptionText.text = Stage[index].Description;
        PlayButton.onClick.RemoveAllListeners();

        PlayButton.onClick.AddListener(() => {
            SceneManager.LoadScene(Stage[index].SceneName);
        });

        foreach (Transform child in RewardContainer.transform) {
            Destroy(child.gameObject);
        }

        Instantiate(Stage[index].Reward[0], RewardContainer.transform.position, Quaternion.identity, RewardContainer.transform);
    }
}
