namespace SilentReverbMod
{
    // Token: 0x02000065 RID: 101
    public class PassiveAbility_SiRvStaggerHeal : PassiveAbilityBase
    {
        // Token: 0x06000185 RID: 389 RVA: 0x00002C3A File Offset: 0x00000E3A
        public override void OnLoseParrying(BattleDiceBehavior behavior)
        {
            if (IsAttackDice(behavior.Detail))
            {
                if (SuccessfullAttack)
                    owner.TakeBreakDamage(8, DamageType.Passive, null, AtkResist.Normal, KeywordBuf.None);

                SuccessfullAttack = false;
            }
        }

        // Token: 0x06000186 RID: 390 RVA: 0x00002C69 File Offset: 0x00000E69
        public override void OnSucceedAttack(BattleDiceBehavior behavior)
        {
            if (SuccessfullAttack)
            {
                owner.breakDetail.RecoverBreak(15);
                SuccessfullAttack = false;
                return;
            }
            SuccessfullAttack = true;
        }

        // Token: 0x04000096 RID: 150
        public bool SuccessfullAttack;
    }
}
