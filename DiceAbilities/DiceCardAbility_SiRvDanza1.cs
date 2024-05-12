using System;

namespace SilentReverbMod
{
    // Token: 0x02000047 RID: 71
    public class DiceCardAbility_SiRvDanza1 : DiceCardAbility_SiRvSilentReverbBase
    {
        // Token: 0x0600011E RID: 286 RVA: 0x00006D60 File Offset: 0x00004F60
        public override void OnSucceedAreaAttack(BattleUnitModel target)
        {
            target.bufListDetail.RemoveBufAll(KeywordBuf.Vibrate);
            int num = base.card.speedDiceResultValue;
            if (this.res == 0)
            {
                num += RandomUtil.Range(-1, 1);
            }
            target.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Vibrate, Math.Max(1, Math.Min(num, 7)), null);
        }

        // Token: 0x0600011F RID: 287 RVA: 0x0000288F File Offset: 0x00000A8F
        public override void BeforeRollDice()
        {
            this.res = base.Resonance();
        }

        // Token: 0x04000061 RID: 97
        private int res;
    }
}
