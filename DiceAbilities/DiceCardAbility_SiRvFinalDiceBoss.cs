namespace SilentReverbMod
{
    // Token: 0x0200005F RID: 95
    public class DiceCardAbility_SiRvFinalDiceBoss : DiceCardAbility_SiRvSilentReverbBase
    {
        // Token: 0x0600016F RID: 367 RVA: 0x000040DC File Offset: 0x000022DC
        public override void OnSucceedAttack()
        {
            base.OnSucceedAttack();
            base.owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Strength, 4, null);
            base.owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Endurance, 4, null);
            base.owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Strength, 4, null);
            base.owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Endurance, 4, null);
        }

        // Token: 0x06000170 RID: 368 RVA: 0x00004140 File Offset: 0x00002340
        public override void OnWinParrying()
        {
            if (base.card == null || base.card.target == null || base.card.target.currentDiceAction == null)
            {
                return;
            }
            base.card.target.currentDiceAction.DestroyDice(DiceMatch.AllDice, DiceUITiming.Start);
        }

        // Token: 0x06000172 RID: 370 RVA: 0x00002BAB File Offset: 0x00000DAB
        public override void OnSucceedAttack(BattleUnitModel target)
        {
            base.OnSucceedAttack(target);
            target.bufListDetail.AddKeywordBufByCard(KeywordBuf.Vibrate, 7, base.owner);
        }

        // Token: 0x17000017 RID: 23
        // (get) Token: 0x06000173 RID: 371 RVA: 0x000025CC File Offset: 0x000007CC
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
