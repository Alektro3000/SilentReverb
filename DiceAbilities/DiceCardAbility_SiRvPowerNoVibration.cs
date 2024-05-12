namespace SilentReverbMod
{
    // Token: 0x0200002F RID: 47
    public class DiceCardAbility_SiRvPowerNoVibration : DiceCardAbility_SiRvSilentReverbBase
    {
        // Token: 0x060000A1 RID: 161 RVA: 0x00003DAC File Offset: 0x00001FAC
        public override void BeforeRollDice()
        {
            base.BeforeRollDice();
            if (this.behavior != null && base.card.target != null && base.card.target.bufListDetail.GetReadyBuf(KeywordBuf.Vibrate) == null)
            {
                this.behavior.ApplyDiceStatBonus(new DiceStatBonus
                {
                    power = 3
                });
            }
        }
    }
}
