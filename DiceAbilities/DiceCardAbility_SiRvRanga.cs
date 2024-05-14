namespace SilentReverbMod
{
    // Token: 0x02000002 RID: 2
    public class DiceCardAbility_SiRvRanga : DiceCardAbility_SiRvSilentReverbBase
    {
        // Token: 0x06000002 RID: 2 RVA: 0x00002058 File Offset: 0x00000258
        public override void BeforeRollDice()
        {
            base.BeforeRollDice();
            if (base.Resonance() > 0)
            {
                behavior.ApplyDiceStatBonus(new DiceStatBonus
                {
                    min = base.Resonance() * 2
                });
            }
        }
    }
}
