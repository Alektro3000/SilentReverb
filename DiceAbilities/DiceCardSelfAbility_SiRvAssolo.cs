namespace SilentReverbMod
{
    // Token: 0x02000023 RID: 35
    public class DiceCardSelfAbility_SiRvAssolo : DiceCardSelfAbility_SiRvBase
    {
        // Token: 0x06000074 RID: 116 RVA: 0x000023B6 File Offset: 0x000005B6
        public override void OnUseCard()
        {
            if (base.IsResonance() > 0)
            {
                base.owner.cardSlotDetail.RecoverPlayPointByCard(base.IsResonance() * 2);
            }
        }

        // Token: 0x06000077 RID: 119 RVA: 0x00002145 File Offset: 0x00000345
        public override bool IsFixedCost()
        {
            return true;
        }

        // Token: 0x06000078 RID: 120 RVA: 0x000023DA File Offset: 0x000005DA
        public override void OnStartBattle()
        {
            this.card.target.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Vibrate, 2, base.owner);
        }
    }
}
