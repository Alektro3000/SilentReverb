namespace SilentReverbMod
{
    // Token: 0x02000026 RID: 38
    public class DiceCardSelfAbility_SiRvEgo : DiceCardSelfAbility_SiRvBase
    {
        // Token: 0x0600007F RID: 127 RVA: 0x00002425 File Offset: 0x00000625
        public override bool OnChooseCard(BattleUnitModel owner)
        {
            return !owner.bufListDetail.HasBuf<BattleUnitBuf_SiRvAlreadySelected>();
        }

        // Token: 0x06000080 RID: 128 RVA: 0x00002435 File Offset: 0x00000635
        public override void OnApplyCard()
        {
            base.owner.bufListDetail.AddBuf(new BattleUnitBuf_SiRvAlreadySelected
            {
                stack = 0
            });
        }

        // Token: 0x06000081 RID: 129 RVA: 0x00003B64 File Offset: 0x00001D64
        public override void OnReleaseCard()
        {
            foreach (BattleUnitBuf battleUnitBuf in base.owner.bufListDetail.GetActivatedBufList())
            {
                if (battleUnitBuf is BattleUnitBuf_SiRvAlreadySelected)
                {
                    battleUnitBuf.Destroy();
                }
            }
        }

        // Token: 0x06000082 RID: 130 RVA: 0x00002453 File Offset: 0x00000653
        public override void OnStartBattle()
        {
            base.OnStartBattle();
            base.owner.bufListDetail.AddBuf(new BattleUnitBuf_SiRvResonanceBuf
            {
                Flags = GetType(),
                stack = GetStack()
            });
        }

        // Token: 0x06000083 RID: 131 RVA: 0x00002488 File Offset: 0x00000688
        public new virtual ResonanceEffect GetType()
        {
            return ResonanceEffect.None;
        }

        // Token: 0x06000084 RID: 132 RVA: 0x00002488 File Offset: 0x00000688
        public virtual int GetStack()
        {
            return 0;
        }
    }
}
