[System.Serializable]
public class SaveData {
    public Stats Stats;
    public Equipment[] Equipment;

    // Define default value for save data
    public SaveData() {
        Stats = new Stats();

        // Default value of Equipment
        Equipment[] equipment = {
            new Equipment("Sword", true),
            new Equipment("Armour"),
            new Equipment("Necklace")
        };
    }
}
