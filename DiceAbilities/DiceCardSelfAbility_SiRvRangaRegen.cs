namespace SilentReverbMod
{
    // Token: 0x0200000D RID: 13
    public class DiceCardSelfAbility_SiRvRangaRegen : DiceCardSelfAbility_SiRvBase
    {
        // Token: 0x17000004 RID: 4
        // (get) Token: 0x0600002F RID: 47 RVA: 0x0000219B File Offset: 0x0000039B
        public override string[] Keywords
        {
            get
            {
                return new string[]
                {
                    "Energy_Keyword"
                };
            }
        }

        // Token: 0x06000030 RID: 48 RVA: 0x00003664 File Offset: 0x00001864
        public override void OnUseCard()
        {
            int num = base.IsResonance();
            if (num > 0)
            {
                base.owner.cardSlotDetail.RecoverPlayPointByCard(num);
                base.owner.allyCardDetail.DrawCards(num);
            }
        }

        // Token: 0x06000033 RID: 51 RVA: 0x00002145 File Offset: 0x00000345
        public override bool IsFixedCost()
        {
            return true;
        }
    }
}
