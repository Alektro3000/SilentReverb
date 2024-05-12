namespace SilentReverbMod
{
    // Token: 0x0200000F RID: 15
    public class DiceCardSelfAbility_SiRvOldBoys : DiceCardSelfAbility_SiRvBase
    {
        // Token: 0x17000006 RID: 6
        // (get) Token: 0x06000039 RID: 57 RVA: 0x0000219B File Offset: 0x0000039B
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

        // Token: 0x0600003A RID: 58 RVA: 0x000036EC File Offset: 0x000018EC
        public override void OnUseCard()
        {
            base.owner.cardSlotDetail.RecoverPlayPointByCard(3);
            base.owner.allyCardDetail.DrawCards(1);
            int num = base.IsResonance();
            if (num > 0)
            {
                base.owner.breakDetail.RecoverBreak(15 * num);
            }
        }
    }
}
