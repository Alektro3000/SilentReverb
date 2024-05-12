namespace SilentReverbMod
{
    // Token: 0x02000083 RID: 131
    public class DiceCardAbility_SiRvVibrateDmg : DiceCardAbility_SiRvSilentReverbBase
    {
        // Token: 0x06000207 RID: 519 RVA: 0x0000BA6C File Offset: 0x00009C6C
        public override void OnSucceedAttack(BattleUnitModel target)
        {
            base.OnSucceedAttack(target);
            if (target == null && target.bufListDetail.GetActivatedBuf(KeywordBuf.Vibrate) == null)
            {
                return;
            }
            int stack = target.bufListDetail.GetActivatedBuf(KeywordBuf.Vibrate).stack;
            target.TakeDamage(stack, DamageType.Card_Ability, null, KeywordBuf.None);
            target.TakeBreakDamage(stack, DamageType.Card_Ability, null, AtkResist.Normal, KeywordBuf.None);
        }
    }
}
