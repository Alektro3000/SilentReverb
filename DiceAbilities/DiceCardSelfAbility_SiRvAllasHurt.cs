namespace SilentReverbMod
{
    // Token: 0x0200007C RID: 124
    public class DiceCardSelfAbility_SiRvAllasHurt : DiceCardSelfAbility_SiRvBase
    {
        // Token: 0x060001F4 RID: 500 RVA: 0x0000B78C File Offset: 0x0000998C
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
                    power = 2
                });
            }
        }

        // Token: 0x060001F5 RID: 501 RVA: 0x00002EC5 File Offset: 0x000010C5
        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            base.BeforeRollDice(behavior);
            if (behavior.TargetDice != null)
            {
                behavior.TargetDice.ApplyDiceStatBonus(new DiceStatBonus
                {
                    max = -2,
                    min = -2
                });
            }
        }
    }
}
