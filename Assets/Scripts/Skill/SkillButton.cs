using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour {
  [SerializeField] private GameObject skillPrefabs;
  [SerializeField] private Button button;

  void Start() {
    button.onClick.AddListener(() => {
      Instantiate(skillPrefabs);
    });
  }
}
