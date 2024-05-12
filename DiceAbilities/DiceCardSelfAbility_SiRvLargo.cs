namespace SilentReverbMod
{
    // Token: 0x02000024 RID: 36
    public class DiceCardSelfAbility_SiRvLargo : DiceCardSelfAbility_SiRvBase
    {
        // Token: 0x06000079 RID: 121 RVA: 0x000023FA File Offset: 0x000005FA
        public override void OnUseCard()
        {
            if (base.IsResonance() > 0)
            {
                base.owner.allyCardDetail.DrawCards(base.IsResonance() * 2);
            }
        }

        // Token: 0x0600007C RID: 124 RVA: 0x00002145 File Offset: 0x00000345
        public override bool IsFixedCost()
        {
            return true;
        }
    }
}
