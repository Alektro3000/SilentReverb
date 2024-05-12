namespace SilentReverbMod
{
    // Token: 0x0200007E RID: 126
    public class DiceCardAbility_SiRvMookHurt : DiceCardAbility_SiRvSilentReverbBase
    {
        // Token: 0x060001FA RID: 506 RVA: 0x0000B864 File Offset: 0x00009A64
        public override void OnSucceedAttack(BattleUnitModel target)
        {
            base.OnSucceedAttack(target);
            if (this.behavior.DiceVanillaValue > 0 && base.card != null && base.card.target != null)
            {
                base.card.target.TakeDamage(this.behavior.DiceVanillaValue, DamageType.Card_Ability, null, KeywordBuf.None);
                base.card.target.TakeBreakDamage(this.behavior.DiceVanillaValue, DamageType.Card_Ability, null, AtkResist.Normal, KeywordBuf.None);
            }
        }

        // Token: 0x060001FC RID: 508 RVA: 0x00002F27 File Offset: 0x00001127
        public override void BeforeRollDice()
        {
            this.behavior.ApplyDiceStatBonus(new DiceStatBonus
            {
                dmgRate = -9999,
                breakRate = -9999
            });
        }
    }
}
