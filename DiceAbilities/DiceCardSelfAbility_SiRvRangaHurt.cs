namespace SilentReverbMod
{
    // Token: 0x02000075 RID: 117
    public class DiceCardSelfAbility_SiRvRangaHurt : DiceCardSelfAbility_SiRvBase
    {
        // Token: 0x060001E3 RID: 483 RVA: 0x0000B500 File Offset: 0x00009700
        public override void OnUseCard()
        {
            for (int i = 0; i < base.IsResonance(); i++)
            {
                this.card.ApplyDiceAbility(DiceMatch.AllAttackDice, new DiceCardAbility_damage3atk());
            }
            if (base.IsResonance() == 0)
            {
                this.card.ApplyDiceAbility(DiceMatch.AllAttackDice, new DiceCardAbility_break3atk());
            }
        }
    }
}
