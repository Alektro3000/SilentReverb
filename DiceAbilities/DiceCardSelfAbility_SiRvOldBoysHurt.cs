namespace SilentReverbMod
{
    // Token: 0x0200007A RID: 122
    public class DiceCardSelfAbility_SiRvOldBoysHurt : DiceCardSelfAbility_SiRvBase
    {
        // Token: 0x060001EE RID: 494 RVA: 0x0000B6AC File Offset: 0x000098AC
        public override void OnUseCard()
        {
            int num = base.IsResonance();
            if (num > 0)
            {
                base.owner.breakDetail.RecoverBreak(15 * num);
            }
            if (base.IsResonance() == 0)
            {
                this.card.owner.bufListDetail.AddKeywordBufByCard(KeywordBuf.Protection, 2, base.owner);
                this.card.owner.bufListDetail.AddKeywordBufByCard(KeywordBuf.BreakProtection, 2, base.owner);
            }
        }

        // Token: 0x17000018 RID: 24
        // (get) Token: 0x060001F0 RID: 496 RVA: 0x00002EB5 File Offset: 0x000010B5
        public override string[] Keywords
        {
            get
            {
                return new string[]
                {
                    "BreakProtect_Keyword"
                };
            }
        }
    }
}
