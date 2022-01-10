[System.Serializable]
public class Stats {
    public double Gold;
    public double AttackPower;
    public double MaxHealth;
    public double MaxMana;
    public double CurrentHealth;
    public double CurrentMana;

    public Stats() {
        Gold = 0;
        AttackPower = 75;
        MaxHealth = 200;
        MaxMana = 100;
        CurrentHealth = 0;
        CurrentMana = 0;
    }
}
