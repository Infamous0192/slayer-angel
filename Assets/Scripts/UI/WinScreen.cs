using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour {
    [SerializeField] private GameObject container;

    public void BackToBase() {
        Time.timeScale = 1;
        SceneManager.LoadScene("Starship");
    }

    private void Start() {
        GameObject[] rewards = StageManager.Instance.stage.Reward;

        foreach (var reward in rewards) {
            var obj = Instantiate(reward, container.transform);
            obj.transform.localScale = new Vector2(1.5f, 1.5f);
        }
    }
}
