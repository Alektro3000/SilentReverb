namespace SilentReverbMod
{
    // Token: 0x0200008F RID: 143
    public class DiceCardSelfAbility_SiRvAdagio : DiceCardSelfAbility_SiRvBase
    {
        // Token: 0x06000222 RID: 546 RVA: 0x0000BD70 File Offset: 0x00009F70
        public override void OnStartBattle()
        {
            card.target.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Vibrate, 3, base.owner);
            card.owner.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Protection, 3, base.owner);
            card.owner.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.BreakProtection, 3, base.owner);
        }

        // Token: 0x1700001B RID: 27
        // (get) Token: 0x06000224 RID: 548 RVA: 0x00003047 File Offset: 0x00001247
        public override string[] Keywords
        {
            get
            {
                return new string[]
                {
                    "Protection_Keyword",
                    "BreakProtect_Keyword"
                };
            }
        }
    }
}
