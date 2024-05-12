namespace SilentReverbMod
{
    // Token: 0x02000078 RID: 120
    public class DiceCardAbility_SiRvAllasHurtPowerDown : DiceCardAbility_SiRvSilentReverbBase
    {
        // Token: 0x060001E9 RID: 489 RVA: 0x00002E89 File Offset: 0x00001089
        public override void BeforeRollDice()
        {
            if (this.behavior.TargetDice != null)
            {
                this.behavior.TargetDice.ApplyDiceStatBonus(new DiceStatBonus
                {
                    power = -3
                });
            }
        }
    }
}
