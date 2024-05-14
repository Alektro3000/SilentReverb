namespace SilentReverbMod
{
    // Token: 0x0200007B RID: 123
    public class DiceCardSelfAbility_SiRvOldBoysHurt2 : DiceCardSelfAbility_SiRvBase
    {
        // Token: 0x060001F1 RID: 497 RVA: 0x0000B71C File Offset: 0x0000991C
        public override void OnUseCard()
        {
            int num = base.IsResonance();
            if (num > 0)
            {
                base.owner.breakDetail.RecoverBreak(40 * num);
            }
            if (base.IsResonance() == 0)
            {
                card.owner.bufListDetail.AddKeywordBufByCard(KeywordBuf.Protection, 4, base.owner);
                card.owner.bufListDetail.AddKeywordBufByCard(KeywordBuf.BreakProtection, 4, base.owner);
            }
        }

        // Token: 0x17000019 RID: 25
        // (get) Token: 0x060001F3 RID: 499 RVA: 0x00002EB5 File Offset: 0x000010B5
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
