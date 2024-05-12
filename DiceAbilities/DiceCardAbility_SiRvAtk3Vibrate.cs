namespace SilentReverbMod
{
    // Token: 0x02000084 RID: 132
    public class DiceCardAbility_SiRvAtk3Vibrate : DiceCardAbility_SiRvSilentReverbBase
    {
        // Token: 0x06000209 RID: 521 RVA: 0x0000BABC File Offset: 0x00009CBC
        public override void OnSucceedAttack(BattleUnitModel target)
        {
            base.OnSucceedAttack(target);
            if (target == null && target.bufListDetail.GetActivatedBuf(KeywordBuf.Vibrate) == null)
            {
                return;
            }
            int stack = target.bufListDetail.GetActivatedBuf(KeywordBuf.Vibrate).stack;
            target.TakeDamage(stack * 3, DamageType.Card_Ability, null, KeywordBuf.None);
            target.TakeBreakDamage(stack * 3, DamageType.Card_Ability, null, AtkResist.Normal, KeywordBuf.None);
        }
    }
}
