namespace SilentReverbMod
{
    // Token: 0x02000031 RID: 49
    public class DiceCardAbility_SiRvCreschendo2 : DiceCardAbility_SiRvSilentReverbBase
    {
        // Token: 0x060000A8 RID: 168 RVA: 0x00002558 File Offset: 0x00000758
        public override void BeforeRollDice()
        {
            this.behavior.ApplyDiceStatBonus(new DiceStatBonus
            {
                dmgRate = -50,
                breakRate = 100
            });
        }
    }
}
