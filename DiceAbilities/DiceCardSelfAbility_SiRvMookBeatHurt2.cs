namespace SilentReverbMod
{
    // Token: 0x02000080 RID: 128
    public class DiceCardSelfAbility_SiRvMookBeatHurt2 : DiceCardSelfAbility_SiRvBase
    {
        // Token: 0x060001FF RID: 511 RVA: 0x0000B93C File Offset: 0x00009B3C
        public override void OnUseCard()
        {
            for (int i = 0; i < base.IsResonance(); i++)
            {
                card.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus
                {
                    min = 8 * base.IsResonance()
                });
            }
            if (base.IsResonance() == 0)
            {
                card.ApplyDiceAbility(DiceMatch.AllAttackDice, new DiceCardAbility_SiRvAtk3Vibrate());
            }
        }
    }
}
