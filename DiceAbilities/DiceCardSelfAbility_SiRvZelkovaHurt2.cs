namespace SilentReverbMod
{
    // Token: 0x02000074 RID: 116
    public class DiceCardSelfAbility_SiRvZelkovaHurt2 : DiceCardSelfAbility_SiRvBase
    {
        // Token: 0x060001E0 RID: 480 RVA: 0x00002DFF File Offset: 0x00000FFF
        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            if (base.IsResonance() > 0 && behavior.TargetDice != null)
            {
                behavior.TargetDice.ApplyDiceStatBonus(new DiceStatBonus
                {
                    max = -5 * base.IsResonance()
                });
            }
        }

        // Token: 0x060001E1 RID: 481 RVA: 0x00002E31 File Offset: 0x00001031
        public override void OnUseCard()
        {
            if (base.IsResonance() == 0)
            {
                card.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus
                {
                    max = 5
                });
            }
        }
    }
}
