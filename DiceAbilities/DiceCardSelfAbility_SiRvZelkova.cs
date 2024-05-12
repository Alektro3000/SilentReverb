namespace SilentReverbMod
{
    // Token: 0x0200000E RID: 14
    public class DiceCardSelfAbility_SiRvZelkova : DiceCardSelfAbility_SiRvBase
    {
        // Token: 0x17000005 RID: 5
        // (get) Token: 0x06000034 RID: 52 RVA: 0x0000219B File Offset: 0x0000039B
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

        // Token: 0x06000035 RID: 53 RVA: 0x000036A0 File Offset: 0x000018A0
        public override void OnUseCard()
        {
            base.owner.allyCardDetail.DrawCards(1);
            int num = base.IsResonance();
            if (num > 0)
            {
                base.owner.cardSlotDetail.RecoverPlayPointByCard(num);
                base.owner.allyCardDetail.DrawCards(num);
            }
        }

        // Token: 0x06000038 RID: 56 RVA: 0x00002145 File Offset: 0x00000345
        public override bool IsFixedCost()
        {
            return true;
        }
    }
}
