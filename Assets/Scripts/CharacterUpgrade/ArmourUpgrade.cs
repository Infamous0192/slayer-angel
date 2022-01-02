public class ArmourUpgrade : CharacterUpgrade {
    public override void OnUpgrade() {
        GameManager.Instance.Data.Stats.MaxHealth += UpgradeAddition;
    }
}
