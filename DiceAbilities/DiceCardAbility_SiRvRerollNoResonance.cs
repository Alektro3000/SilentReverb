namespace SilentReverbMod
{
    // Token: 0x0200002A RID: 42
    public class DiceCardAbility_SiRvRerollNoResonance : DiceCardAbility_SiRvSilentReverbBase
    {
        // Token: 0x06000091 RID: 145 RVA: 0x00002499 File Offset: 0x00000699
        public override void AfterAction()
        {
            base.AfterAction();
            if (this.count == 0 && base.Resonance() == 0)
            {
                base.ActivateBonusAttackDice();
                this.count++;
            }
        }

        // Token: 0x04000016 RID: 22
        private int count;
    }
}
