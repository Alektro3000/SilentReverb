namespace SilentReverbMod
{
    // Token: 0x0200008D RID: 141
    public class DiceCardAbility_SiRvCrystalDiceHurt : DiceCardAbility_SiRvSilentReverbBase
    {
        // Token: 0x0600021D RID: 541 RVA: 0x000022B3 File Offset: 0x000004B3
        public override void OnSucceedAttack()
        {
            if (base.Resonance() > 0)
            {
                base.card.GetDiceBehaviorList()[0].behaviourInCard.ActionScript = "BlackReverbDualWield";
            }
        }

        // Token: 0x0600021F RID: 543 RVA: 0x00002558 File Offset: 0x00000758
        public override void BeforeRollDice()
        {
            this.behavior.ApplyDiceStatBonus(new DiceStatBonus
            {
                dmgRate = -50,
                breakRate = 100
            });
        }
    }
}
