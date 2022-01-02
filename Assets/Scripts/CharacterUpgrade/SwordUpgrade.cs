public class SwordUpgrade : CharacterUpgrade {
    public override void OnUpgrade() {
        GameManager.Instance.Data.Stats.AttackPower += UpgradeAddition;
    }
}
