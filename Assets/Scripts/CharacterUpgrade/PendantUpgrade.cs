public class PendantUpgrade : CharacterUpgrade {
    public override void OnUpgrade() {
        GameManager.Instance.Data.Stats.MaxMana += UpgradeAddition;
    }
}
