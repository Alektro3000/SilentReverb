namespace SilentReverbMod
{
    // Token: 0x02000018 RID: 24
    public class DiceCardAbility_SiRvCrystalDice : DiceCardAbility_SiRvSilentReverbBase
    {
        // Token: 0x06000054 RID: 84 RVA: 0x0000390C File Offset: 0x00001B0C
        public override void OnSucceedAttack(BattleUnitModel target)
        {
            base.OnSucceedAttack(target);
            int num = 0;
            if (target == null)
            {
                return;
            }
            if (target.bufListDetail.GetActivatedBuf(KeywordBuf.Vibrate) != null)
            {
                num += target.bufListDetail.GetActivatedBuf(KeywordBuf.Vibrate).stack;
            }
            if (target.bufListDetail.GetReadyBuf(KeywordBuf.Vibrate) != null)
            {
                num += target.bufListDetail.GetReadyBuf(KeywordBuf.Vibrate).stack;
            }
            if (num > 0)
            {
                target.TakeBreakDamage(num, DamageType.Card_Ability, null, AtkResist.Normal, KeywordBuf.None);
            }
        }

        // Token: 0x06000056 RID: 86 RVA: 0x000022B3 File Offset: 0x000004B3
        public override void OnSucceedAttack()
        {
            if (base.Resonance() > 0)
            {
                base.card.GetDiceBehaviorList()[0].behaviourInCard.ActionScript = "BlackReverbDualWield";
            }
        }
    }
}
