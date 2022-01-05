[System.Serializable]
public class SaveData {
    public Stats Stats;
    public Equipment[] Equipment;
    public Stage[] Stage;

    // Define default value for save data
    public SaveData() {
        // Default value of Equipment
        Equipment[] equipment = {
            new Equipment("Sword", true),
            new Equipment("Armour"),
            new Equipment("Pendant")
        };

        // Default value of Stage
        Stage[] stage = { };

        Stats = new Stats();
        Equipment = equipment;
        Stage = stage;
    }
}
