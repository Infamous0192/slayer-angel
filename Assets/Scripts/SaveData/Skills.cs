[System.Serializable]
public class Skills {
    public string Name;
    public int Level;
    public bool IsUnlocked;

    public Skills(string name) {
        Name = name;
        Level = 1;
        IsUnlocked = false;
    }

    public Skills(string name, bool isUnlocked) {
        Name = name;
        Level = 1;
        IsUnlocked = isUnlocked;
    }
}
