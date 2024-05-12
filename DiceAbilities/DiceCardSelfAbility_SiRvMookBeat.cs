namespace SilentReverbMod
{
    // Token: 0x0200000A RID: 10
    public class DiceCardSelfAbility_SiRvMookBeat : DiceCardSelfAbilityBase
    {
        // Token: 0x17000003 RID: 3
        // (get) Token: 0x06000026 RID: 38 RVA: 0x0000219B File Offset: 0x0000039B
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

        // Token: 0x06000027 RID: 39 RVA: 0x000021AB File Offset: 0x000003AB
        public override void OnUseCard()
        {
            base.owner.cardSlotDetail.RecoverPlayPointByCard(3);
            base.owner.allyCardDetail.DrawCards(1);
        }
    }
}
