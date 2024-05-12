namespace SilentReverbMod
{
    // Token: 0x0200008A RID: 138
    public class DiceCardAbility_SiRvAddPoorAtk : DiceCardAbilityBase
    {
        // Token: 0x06000217 RID: 535 RVA: 0x0000301B File Offset: 0x0000121B
        public override void OnSucceedAttack(BattleUnitModel target)
        {
            base.OnSucceedAttack(target);
            base.card.target.allyCardDetail.AddNewCard(new LorId("SilentReverb", 43), false);
        }
    }
}
