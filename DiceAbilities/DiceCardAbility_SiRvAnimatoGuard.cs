namespace SilentReverbMod
{
    // Token: 0x02000040 RID: 64
    public class DiceCardAbility_SiRvAnimatoGuard : DiceCardAbility_SiRvSilentReverbBase
    {
        // Token: 0x06000107 RID: 263 RVA: 0x000027EC File Offset: 0x000009EC
        public override void OnLoseParrying()
        {
            base.card.AddDiceAdder(DiceMatch.AllDice, 3);
        }
    }
}
