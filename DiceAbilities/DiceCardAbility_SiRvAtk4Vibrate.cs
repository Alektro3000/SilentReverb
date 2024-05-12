namespace SilentReverbMod
{
    // Token: 0x02000091 RID: 145
    public class DiceCardAbility_SiRvAtk4Vibrate : DiceCardAbility_SiRvSilentReverbBase
    {
        // Token: 0x06000229 RID: 553 RVA: 0x0000BEA4 File Offset: 0x0000A0A4
        public override void OnSucceedAttack(BattleUnitModel target)
        {
            base.OnSucceedAttack(target);
            if (target == null && target.bufListDetail.GetActivatedBuf(KeywordBuf.Vibrate) == null)
            {
                return;
            }
            int stack = target.bufListDetail.GetActivatedBuf(KeywordBuf.Vibrate).stack;
            target.TakeDamage(stack * 4, DamageType.Card_Ability, null, KeywordBuf.None);
            target.TakeBreakDamage(stack * 4, DamageType.Card_Ability, null, AtkResist.Normal, KeywordBuf.None);
        }
    }
}
