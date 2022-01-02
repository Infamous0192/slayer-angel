public class Equipment {
    public string Name;
    public int Level;
    public bool IsUnlocked;

    public Equipment(string name) {
        Name = name;
        Level = 1;
        IsUnlocked = false;
    }

    public Equipment(string name, bool isUnlocked) {
        Name = name;
        IsUnlocked = isUnlocked;
    }
}
