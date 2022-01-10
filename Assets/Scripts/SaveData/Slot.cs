[System.Serializable]
public class Slot {
    public bool IsUnlocked;
    public string Skill;

    public Slot() {
        Skill = "";
        IsUnlocked = false;
    }

    public Slot(string skill) {
        Skill = skill;
        IsUnlocked = true;
    }
}
