using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour {
    public string Name = "";
    public string Description = "";
    public float BaseManaCost = 0;
    public int Level = 0;
    public float Cooldown = 0;
    public bool IsUnlocked = false;
}
