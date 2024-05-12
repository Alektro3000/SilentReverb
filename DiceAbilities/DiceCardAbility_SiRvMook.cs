namespace SilentReverbMod
{
    // Token: 0x02000012 RID: 18
    public class DiceCardAbility_SiRvMook : DiceCardAbility_SiRvSilentReverbBase
    {
        // Token: 0x06000043 RID: 67 RVA: 0x000037A0 File Offset: 0x000019A0
        public override void OnSucceedAttack(BattleUnitModel target)
        {
            base.OnSucceedAttack(target);
            if (target == null && target.bufListDetail.GetActivatedBuf(KeywordBuf.Vibrate) == null)
            {
                return;
            }
            int stack = target.bufListDetail.GetActivatedBuf(KeywordBuf.Vibrate).stack;
            target.TakeDamage(stack * 2, DamageType.Card_Ability, null, KeywordBuf.None);
            if (base.Resonance() > 0)
            {
                target.TakeBreakDamage(stack * 2 * base.Resonance(), DamageType.Card_Ability, null, AtkResist.Normal, KeywordBuf.None);
            }
        }
    }
}
