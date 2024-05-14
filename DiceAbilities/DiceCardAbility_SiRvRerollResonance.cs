using System;

namespace SilentReverbMod
{
    // Token: 0x0200002C RID: 44
    public class DiceCardAbility_SiRvRerollResonance : DiceCardAbility_SiRvSilentReverbBase
    {
        // Token: 0x06000098 RID: 152 RVA: 0x00003D4C File Offset: 0x00001F4C
        public override void AfterAction()
        {
            base.AfterAction();
            BattleUnitBuf activatedBuf = base.card.target.bufListDetail.GetActivatedBuf(KeywordBuf.Vibrate);
            if (activatedBuf == null)
            {
                return;
            }
            if (count < Math.Min(activatedBuf.stack, 4) * base.Resonance())
            {
                base.ActivateBonusAttackDice();
                count++;
            }
        }

        // Token: 0x04000018 RID: 24
        private int count;
    }
}
