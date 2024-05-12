namespace SilentReverbMod
{
    // Token: 0x0200007D RID: 125
    public class DiceCardSelfAbility_SiRvAllasHurt2 : DiceCardSelfAbility_SiRvBase
    {
        // Token: 0x060001F7 RID: 503 RVA: 0x0000B7F8 File Offset: 0x000099F8
        public override void OnUseCard()
        {
            if (base.IsResonance() > 0)
            {
                this.card.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus
                {
                    max = 3 * base.IsResonance(),
                    min = base.IsResonance()
                });
            }
            if (base.IsResonance() == 0)
            {
                this.card.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus
                {
                    power = 4
                });
            }
        }

        // Token: 0x060001F8 RID: 504 RVA: 0x00002EF6 File Offset: 0x000010F6
        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            base.BeforeRollDice(behavior);
            if (behavior.TargetDice != null)
            {
                behavior.TargetDice.ApplyDiceStatBonus(new DiceStatBonus
                {
                    max = -4,
                    min = -4
                });
            }
        }
    }
}
