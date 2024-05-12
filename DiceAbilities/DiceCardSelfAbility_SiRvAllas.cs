namespace SilentReverbMod
{
    // Token: 0x02000013 RID: 19
    public class DiceCardSelfAbility_SiRvAllas : DiceCardSelfAbility_SiRvBase
    {
        // Token: 0x06000045 RID: 69 RVA: 0x00002203 File Offset: 0x00000403
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
        }

        // Token: 0x06000048 RID: 72 RVA: 0x0000223E File Offset: 0x0000043E
        public override void BeforeRollDice(BattleDiceBehavior behavior)
        {
            base.BeforeRollDice(behavior);
            if (behavior.TargetDice != null)
            {
                behavior.TargetDice.ApplyDiceStatBonus(new DiceStatBonus
                {
                    power = -2
                });
            }
        }
    }
}
