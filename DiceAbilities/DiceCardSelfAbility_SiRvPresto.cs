using LOR_DiceSystem;

namespace SilentReverbMod
{
    // Token: 0x0200009B RID: 155
    public class DiceCardSelfAbility_SiRvPresto : DiceCardSelfAbility_SiRvBase
    {
        // Token: 0x06000244 RID: 580 RVA: 0x000030D0 File Offset: 0x000012D0
        public override void OnUseCard()
        {
            base.owner.bufListDetail.AddReadyBuf(new BattleUnitBuf_SilentPlusDice());
            base.owner.bufListDetail.AddReadyBuf(new DiceCardSelfAbility_SiRvPresto.SupBuf());
        }

        // Token: 0x0200009C RID: 156
        public class SupBuf : BattleUnitBuf
        {
            // Token: 0x06000247 RID: 583 RVA: 0x000024EB File Offset: 0x000006EB
            public override void OnRoundEnd()
            {
                Destroy();
            }

            // Token: 0x06000248 RID: 584 RVA: 0x0000C2B4 File Offset: 0x0000A4B4
            public override void OnRollSpeedDice()
            {
                int num = 8;
                foreach (SpeedDice speedDice in _owner.speedDiceResult)
                {
                    if (speedDice.value != num)
                    {
                        speedDice.value = num;
                    }
                }
            }
        }
    }
}
