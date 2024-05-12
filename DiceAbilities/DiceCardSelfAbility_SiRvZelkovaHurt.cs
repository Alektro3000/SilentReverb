namespace SilentReverbMod
{
    // Token: 0x02000073 RID: 115
    public class DiceCardSelfAbility_SiRvZelkovaHurt : DiceCardSelfAbility_SiRvBase
    {
        // Token: 0x060001DE RID: 478 RVA: 0x00002DA6 File Offset: 0x00000FA6
        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            if (base.IsResonance() > 0 && behavior.TargetDice != null)
            {
                behavior.TargetDice.ApplyDiceStatBonus(new DiceStatBonus
                {
                    max = -3 * base.IsResonance()
                });
            }
        }

        // Token: 0x060001DF RID: 479 RVA: 0x00002DD8 File Offset: 0x00000FD8
        public override void OnUseCard()
        {
            if (base.IsResonance() == 0)
            {
                this.card.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus
                {
                    max = 3
                });
            }
        }
    }
}
