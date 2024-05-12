namespace SilentReverbMod
{
    // Token: 0x0200001B RID: 27
    public class DiceCardAbility_SiRvAppas : DiceCardAbility_SiRvSilentReverbBase
    {
        // Token: 0x0600005C RID: 92 RVA: 0x000039B4 File Offset: 0x00001BB4
        public override void OnSucceedAttack(BattleUnitModel target)
        {
            base.OnSucceedAttack(target);
            for (int i = 0; i < base.Resonance(); i++)
            {
                base.card.ApplyDiceAbility(DiceMatch.NextDice, new DiceCardAbility_SiRvAdd3Vibrate());
            }
        }
    }
}
