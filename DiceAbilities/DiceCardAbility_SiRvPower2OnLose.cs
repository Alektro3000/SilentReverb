namespace SilentReverbMod
{
    // Token: 0x0200001E RID: 30
    public class DiceCardAbility_SiRvPower2OnLose : DiceCardAbility_SiRvSilentReverbBase
    {
        // Token: 0x06000065 RID: 101 RVA: 0x00002353 File Offset: 0x00000553
        public override void OnLoseParrying()
        {
            base.OnLoseParrying();
            if (base.Resonance() > 0)
            {
                base.card.AddDiceAdder(DiceMatch.NextDice, 2 * base.Resonance());
            }
        }
    }
}
