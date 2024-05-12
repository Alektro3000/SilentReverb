namespace SilentReverbMod
{
    // Token: 0x0200008B RID: 139
    public class DiceCardAbility_SiRvAdd3PoorAtk : DiceCardAbilityBase
    {
        // Token: 0x06000219 RID: 537 RVA: 0x0000BBCC File Offset: 0x00009DCC
        public override void OnSucceedAttack(BattleUnitModel target)
        {
            base.OnSucceedAttack(target);
            base.card.target.allyCardDetail.AddNewCard(new LorId("SilentReverb", 43), false);
            base.card.target.allyCardDetail.AddNewCard(new LorId("SilentReverb", 43), false);
            base.card.target.allyCardDetail.AddNewCard(new LorId("SilentReverb", 43), false);
        }
    }
}
