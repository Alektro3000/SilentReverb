namespace SilentReverbMod
{
    // Token: 0x02000085 RID: 133
    public class DiceCardSelfAbility_SiRvAppasHurtEffect : DiceCardSelfAbility_SiRvBase
    {
        // Token: 0x0600020B RID: 523 RVA: 0x0000BB10 File Offset: 0x00009D10
        public override void OnUseCard()
        {
            int num = base.IsResonance();
            if (num > 0)
            {
                this.card.target.cardSlotDetail.LoseWhenStartRound(3 * num);
            }
            if (base.IsResonance() == 0)
            {
                this.card.target.allyCardDetail.DiscardACardLowest();
            }
        }
    }
}
