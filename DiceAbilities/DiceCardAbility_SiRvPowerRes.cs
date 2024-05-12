namespace SilentReverbMod
{
    // Token: 0x0200002D RID: 45
    public class DiceCardAbility_SiRvPowerRes : DiceCardAbility_SiRvSilentReverbBase
    {
        // Token: 0x0600009D RID: 157 RVA: 0x000024F3 File Offset: 0x000006F3
        public override void BeforeRollDice()
        {
            base.BeforeRollDice();
            if (base.Resonance() != 0 && this.behavior != null)
            {
                this.behavior.ApplyDiceStatBonus(new DiceStatBonus
                {
                    power = 3 * base.Resonance()
                });
            }
        }
    }
}
