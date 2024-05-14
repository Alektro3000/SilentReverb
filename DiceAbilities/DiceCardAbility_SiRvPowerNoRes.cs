namespace SilentReverbMod
{
    // Token: 0x0200002E RID: 46
    public class DiceCardAbility_SiRvPowerNoRes : DiceCardAbility_SiRvSilentReverbBase
    {
        // Token: 0x060000A0 RID: 160 RVA: 0x00002529 File Offset: 0x00000729
        public override void BeforeRollDice()
        {
            base.BeforeRollDice();
            if (base.Resonance() == 0 && behavior != null)
            {
                behavior.ApplyDiceStatBonus(new DiceStatBonus
                {
                    power = 3
                });
            }
        }
    }
}
