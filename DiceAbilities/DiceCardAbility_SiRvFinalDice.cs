namespace SilentReverbMod
{
    // Token: 0x02000036 RID: 54
    public class DiceCardAbility_SiRvFinalDice : DiceCardAbility_SiRvSilentReverbBase
    {
        // Token: 0x060000BC RID: 188 RVA: 0x000040DC File Offset: 0x000022DC
        public override void OnSucceedAttack()
        {
            base.OnSucceedAttack();
            base.owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Strength, 4, null);
            base.owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Endurance, 4, null);
            base.owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Strength, 4, null);
            base.owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Endurance, 4, null);
        }

        // Token: 0x060000BD RID: 189 RVA: 0x00004140 File Offset: 0x00002340
        public override void OnWinParrying()
        {
            if (base.card == null || base.card.target == null || base.card.target.currentDiceAction == null)
            {
                return;
            }
            base.card.target.currentDiceAction.DestroyDice(DiceMatch.AllDice, DiceUITiming.Start);
        }

        // Token: 0x1700000A RID: 10
        // (get) Token: 0x060000BE RID: 190 RVA: 0x000025CC File Offset: 0x000007CC
        public override string[] Keywords
        {
            get
            {
                return new string[]
                {
                    "Strength_Keyword",
                    "Endurance_Keyword"
                };
            }
        }
    }
}
