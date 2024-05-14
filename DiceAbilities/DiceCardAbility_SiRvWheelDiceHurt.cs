namespace SilentReverbMod
{
    // Token: 0x02000087 RID: 135
    public class DiceCardAbility_SiRvWheelDiceHurt : DiceCardAbility_SiRvSilentReverbBase
    {
        // Token: 0x0600020D RID: 525 RVA: 0x0000BB60 File Offset: 0x00009D60
        public override void OnSucceedAttack(BattleUnitModel target)
        {
            if (base.Resonance() == 0 && base.card != null && base.card.target != null)
            {
                base.card.target.TakeDamage(behavior.DiceResultValue * 5, DamageType.Card_Ability, null, KeywordBuf.None);
                base.card.target.TakeBreakDamage(behavior.DiceResultValue * 5, DamageType.Card_Ability, null, AtkResist.Normal, KeywordBuf.None);
            }
        }

        // Token: 0x0600020E RID: 526 RVA: 0x0000237D File Offset: 0x0000057D
        public override void BeforeRollDice()
        {
            if (base.Resonance() > 0)
            {
                behavior.ApplyDiceStatBonus(new DiceStatBonus
                {
                    dmgRate = 100 * base.Resonance(),
                    breakDmg = 100 * base.Resonance()
                });
            }
        }

        // Token: 0x0600020F RID: 527 RVA: 0x00003A70 File Offset: 0x00001C70
        public override void OnWinParrying()
        {
            if (base.card == null || base.card.target == null || base.card.target.currentDiceAction == null)
            {
                return;
            }
            base.card.target.currentDiceAction.DestroyDice(DiceMatch.NextDice, DiceUITiming.Start);
        }
    }
}
