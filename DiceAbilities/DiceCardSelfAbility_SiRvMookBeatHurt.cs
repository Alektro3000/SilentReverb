namespace SilentReverbMod
{
    // Token: 0x0200007F RID: 127
    public class DiceCardSelfAbility_SiRvMookBeatHurt : DiceCardSelfAbility_SiRvBase
    {
        // Token: 0x060001FD RID: 509 RVA: 0x0000B8DC File Offset: 0x00009ADC
        public override void OnUseCard()
        {
            for (int i = 0; i < base.IsResonance(); i++)
            {
                this.card.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus
                {
                    min = 5 * base.IsResonance()
                });
            }
            if (base.IsResonance() == 0)
            {
                this.card.ApplyDiceAbility(DiceMatch.AllAttackDice, new DiceCardAbility_SiRvAtk3Vibrate());
            }
        }
    }
}
