namespace SilentReverbMod
{
    // Token: 0x02000092 RID: 146
    public class DiceCardSelfAbility_SiRvLento : DiceCardSelfAbility_SiRvBase
    {
        // Token: 0x0600022B RID: 555 RVA: 0x0000305F File Offset: 0x0000125F
        public override void OnUseCard()
        {
            card.ApplyDiceAbility(DiceMatch.AllAttackDice, new DiceCardAbility_immuneDestory());
        }

        // Token: 0x0600022D RID: 557 RVA: 0x0000BEF8 File Offset: 0x0000A0F8
        public override void OnStartParrying()
        {
            if (base.IsResonance() == 0)
            {
                card.target.bufListDetail.AddKeywordBufByCard(KeywordBuf.NullifyPower, 1, base.owner);
                card.target.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.NullifyPower, 1, base.owner);
            }
            if (base.IsResonance() > 0)
            {
                card.target.bufListDetail.AddBuf(new DiceCardSelfAbility_SiRvLento.SupBuf());
            }
        }

        // Token: 0x02000093 RID: 147
        public class SupBuf : BattleUnitBuf
        {
            // Token: 0x0600022E RID: 558 RVA: 0x00003077 File Offset: 0x00001277
            public override void ChangeDiceResult(BattleDiceBehavior behavior, ref int diceResult)
            {
                diceResult = behavior.GetDiceMin();
            }

            // Token: 0x06000230 RID: 560 RVA: 0x000024EB File Offset: 0x000006EB
            public override void OnEndParrying()
            {
                Destroy();
            }
        }
    }
}
