namespace SilentReverbMod
{
    // Token: 0x02000021 RID: 33
    public class DiceCardAbility_SiRvResonateDice : DiceCardAbility_SiRvSilentReverbBase
    {
        // Token: 0x0600006E RID: 110 RVA: 0x00003AC4 File Offset: 0x00001CC4
        public override void BeforeRollDice()
        {
            base.BeforeRollDice();
            int num = base.Resonance();
            if (num <= 0)
            {
                return;
            }
            this.behavior.ApplyDiceStatBonus(new DiceStatBonus
            {
                min = num * 2,
                max = num * 2
            });
        }
    }
}
