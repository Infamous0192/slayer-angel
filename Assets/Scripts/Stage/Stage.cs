using UnityEngine;

[System.Serializable]
public class Stage {
    public string SceneName;
    public string Name;
    public string Title;
    public string Description;
    public double Distance;
    public float Checkpoint;
    public bool IsUnlocked;
    public GameObject[] Reward;
}
