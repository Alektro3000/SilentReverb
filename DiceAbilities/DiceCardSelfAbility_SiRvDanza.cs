namespace SilentReverbMod
{
    // Token: 0x02000046 RID: 70
    public class DiceCardSelfAbility_SiRvDanza : DiceCardSelfAbility_SiRvBase
    {
        // Token: 0x06000119 RID: 281 RVA: 0x00002858 File Offset: 0x00000A58
        public override void OnUseCard()
        {
            this.res = base.IsResonance();
            if (this.res != 0)
            {
                base.owner.bufListDetail.AddReadyBuf(new BattleUnitBuf_SilentPlusDice
                {
                    stack = this.res
                });
            }
        }

        // Token: 0x04000060 RID: 96
        private int res;
    }
}
