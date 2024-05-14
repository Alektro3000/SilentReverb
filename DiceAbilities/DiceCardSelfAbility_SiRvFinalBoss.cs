namespace SilentReverbMod
{
    // Token: 0x0200005E RID: 94
    public class DiceCardSelfAbility_SiRvFinalBoss : DiceCardSelfAbility_SiRvBase
    {
        // Token: 0x0600016C RID: 364 RVA: 0x0000280F File Offset: 0x00000A0F
        public override void OnUseCard()
        {
            base.OnUseCard();
            if (base.IsResonance() != 0)
            {
                card.target.bufListDetail.AddBuf(new BattleUnitBuf_SilentFinalPlus
                {
                    stack = base.IsResonance()
                });
            }
        }
    }
}
