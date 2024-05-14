namespace SilentReverbMod
{
    // Token: 0x0200005C RID: 92
    public class DiceCardSelfAbility_SiRvPoor : DiceCardSelfAbility_SiRvBase
    {
        // Token: 0x06000166 RID: 358 RVA: 0x00002B4E File Offset: 0x00000D4E
        public override void OnRoundStart_inHand(BattleUnitModel unit, BattleDiceCardModel self)
        {
            unit.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Vibrate, 1, null);
            unit.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Disarm, 1, null);
        }

        // Token: 0x06000167 RID: 359 RVA: 0x00002B6D File Offset: 0x00000D6D
        public override void OnUseCard()
        {
            card.card.exhaust = true;
        }

        // Token: 0x06000168 RID: 360 RVA: 0x00002B80 File Offset: 0x00000D80
        public override void OnDiscard(BattleUnitModel unit, BattleDiceCardModel self)
        {
            base.OnDiscard(unit, self);
            card.card.exhaust = true;
        }

        // Token: 0x17000016 RID: 22
        // (get) Token: 0x06000169 RID: 361 RVA: 0x00002B9B File Offset: 0x00000D9B
        public override string[] Keywords
        {
            get
            {
                return new string[]
                {
                    "Disarm_Keyword"
                };
            }
        }
    }
}
