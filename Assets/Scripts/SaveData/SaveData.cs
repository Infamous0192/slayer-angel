[System.Serializable]
public class SaveData {
    public Stats Stats;
    public Equipment[] Equipment;
    public Skills[] Skill;
    public Slot[] Slot;
    public Stage[] Stage;

    // Define default value for save data
    public SaveData() {
        Equipment[] equipment = {
            new Equipment("Sword", true),
            new Equipment("Armour", true),
            new Equipment("Pendant")
        };

        Skills[] skill = {
            new Skills("Shockblast", true),
            new Skills("AuraCharge", true),
            new Skills("HypersonicStab")
        };

        Slot[] slot = {
            new Slot("Shockblast"),
            new Slot(""),
            new Slot(),
            new Slot()
        };

        // Default value of Stage
        Stage[] stage = { };

        Stats = new Stats();
        Equipment = equipment;
        Skill = skill;
        Slot = slot;
        Stage = stage;
    }
}
