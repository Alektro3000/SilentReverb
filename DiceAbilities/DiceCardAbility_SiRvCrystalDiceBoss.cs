namespace SilentReverbMod
{
    // Token: 0x02000060 RID: 96
    public class DiceCardAbility_SiRvCrystalDiceBoss : DiceCardAbility_SiRvSilentReverbBase
    {
        // Token: 0x06000174 RID: 372 RVA: 0x000081FC File Offset: 0x000063FC
        public override void OnSucceedAttack(BattleUnitModel target)
        {
            base.OnSucceedAttack(target);
            target.bufListDetail.AddKeywordBufByCard(KeywordBuf.Vibrate, 7, base.owner);
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

        // Token: 0x06000176 RID: 374 RVA: 0x000040DC File Offset: 0x000022DC
        public override void OnSucceedAttack()
        {
            base.OnSucceedAttack();
            base.owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Strength, 4, null);
            base.owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Endurance, 4, null);
            base.owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Strength, 4, null);
            base.owner.bufListDetail.AddKeywordBufThisRoundByEtc(KeywordBuf.Endurance, 4, null);
        }
    }
}
