namespace SilentReverbMod
{
    // Token: 0x02000088 RID: 136
    public class DiceCardAbility_SiRvAppasBuff : DiceCardAbility_SiRvSilentReverbBase
    {
        // Token: 0x06000211 RID: 529 RVA: 0x00002F6D File Offset: 0x0000116D
        public override void OnSucceedAttack()
        {
            base.OnSucceedAttack();
            base.owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Strength, 2, null);
            base.owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Endurance, 2, null);
        }

        // Token: 0x06000213 RID: 531 RVA: 0x00002F9D File Offset: 0x0000119D
        public override void OnSucceedAttack(BattleUnitModel target)
        {
            base.OnSucceedAttack(target);
            target.bufListDetail.AddKeywordBufByCard(KeywordBuf.Binding, 4, base.owner);
            target.bufListDetail.AddKeywordBufByCard(KeywordBuf.Paralysis, 2, base.owner);
        }

        // Token: 0x1700001A RID: 26
        // (get) Token: 0x06000214 RID: 532 RVA: 0x00002FCD File Offset: 0x000011CD
        public override string[] Keywords
        {
            get
            {
                return new string[]
                {
                    "Strength_Keyword",
                    "Endurance_Keyword",
                    "Binding_Keyword",
                    "Paralysis_Keyword"
                };
            }
        }
    }
}
